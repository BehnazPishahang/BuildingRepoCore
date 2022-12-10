using Application.Common;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebApi.Controllers.BaseController;


public abstract class BaseController<TInput, TOutput> : ControllerBase
{
    // protected readonly GenericRepository<TEntity> _genericRepository;
    
    protected BaseController(DataContext context)
    {
        // _genericRepository = new GenericRepository<TEntity>(context);
    }

    protected abstract Task<TOutput> GetById(TInput request);
    
    protected abstract Task<TOutput> GetAll();
}