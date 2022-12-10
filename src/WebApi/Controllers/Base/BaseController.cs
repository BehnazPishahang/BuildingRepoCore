using Application.Common;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebApi.Controllers.BaseController;


public abstract class BaseController<TContract> : ControllerBase
{
    public abstract Task<TContract> GetById(TContract request);
    
    public abstract Task<List<TContract>> GetAll();
}