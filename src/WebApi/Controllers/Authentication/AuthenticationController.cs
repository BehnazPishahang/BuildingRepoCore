using Application.User;
using Building.Core.WebApi;
using Commons.Extensions;
using Commons.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceModel.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Authentication
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppConfiguration> _configuration;

        public AuthenticationController(IUserRepository UserRepository, IOptions<AppConfiguration> options)
        {
            _userRepository = UserRepository;
            _configuration = options;
        }

        [HttpPost]
        [Route("api/v1/Login")]
        public async Task<AuthenticationResponse> Login([FromBody] AuthenticationRequest request)
        {
            #region ValidateInput
            if (request == null)
                return new AuthenticationResponse() { Message = "پارامتر ورودی خالی است." };

            if (request.Family.IsNullOrWhiteSpace())
                return new AuthenticationResponse() { Message = "پارامتر نام خانوادگی خالی است." };

            if (request.Password.IsNullOrWhiteSpace())
                return new AuthenticationResponse() { Message = "پارامتر پسوورد خالی است." };




            #endregion

            string jwtToken = null;
            var TheUser = await _userRepository.GetByuserANDpass(request.Family, request.Password);
            if (TheUser == null)
                return new AuthenticationResponse() { Message = "نام کاربری یا پسورد غیرمعتبر است." };


            jwtToken = GenerateJwtToken(TheUser);

            return new AuthenticationResponse() { AccessToken = jwtToken };
        }

        private string GenerateJwtToken(Domain.User.User theUser)
        {
            var jwtTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.Value.JwtConfig.Secret);



            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    // new Claim("IsDisable", "true"),
                    new Claim("permissions", this.GetPermissions(theUser)),
                    new Claim("Family", theUser.Family),
                    new Claim(JwtRegisteredClaimNames.Sub, theUser.Family),
                    new Claim(JwtRegisteredClaimNames.Email, value:theUser.Family),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = GetExpireDateTime(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private DateTime? GetExpireDateTime()
        {
            var jWtTokenValidTime = _configuration.Value.JWTTokenValidMinute;
            var ts = TimeSpan.FromMinutes(10);
            if (jWtTokenValidTime != null)
            {
                ts = TimeSpan.Parse(jWtTokenValidTime);
            }
            return DateTime.Now.AddMinutes(ts.TotalMinutes); //string.IsNullOrEmpty(jWTTokenValidMinute) ? DateTime.Now.AddMinutes(30) : DateTime.Now.AddMinutes(Convert.ToInt32(jWTTokenValidMinute));
        }

        private string GetPermissions(Domain.User.User theUser)
        {

            if (theUser.TheUserAccessList == null)
            {
                return ";All;";
            }
            var theUserAccessTypeCodes = string.Join(';', theUser.TheUserAccessList.Select(x => x.TheUserAccessType.Code));
            return theUserAccessTypeCodes;
        }

        public class ActionFilterModelStateValidation : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var errorsConcatedWithNewLine = string.Join(System.Environment.NewLine, errors);

                    context.Result = new BadRequestObjectResult(new
                    {
                        Result = new Result()
                        {
                            Code = 2000,
                            Message = "درخواست ارسال شده معتبر نیست.",
                            Description = errorsConcatedWithNewLine,
                        }
                    });
                }
            }
        }

        
    }
}
