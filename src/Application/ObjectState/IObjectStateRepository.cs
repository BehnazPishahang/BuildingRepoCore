using Application.Common;

namespace Application.ObjectState;

public interface IObjectStateRepository:IGenericRepository<Domain.ObjectState.ObjectState>
{
    Domain.ObjectState.ObjectState GetbyCode(String Code);
}