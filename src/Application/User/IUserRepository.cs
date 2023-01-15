using Application.Common;

namespace Application.User
{
    public interface IUserRepository: IGenericRepository<Domain.User.User>
    {
        Task<Domain.User.User> GetByuserANDpass(string UserName, string Password);
    }
}