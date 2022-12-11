using Application.Common;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebApi.Controllers.BaseController;


public abstract class BaseController<TInput, TOutput> : ControllerBase
{
    public abstract Task<TOutput> GetById(TInput request);
    
    public abstract Task<TOutput> GetAll();
}