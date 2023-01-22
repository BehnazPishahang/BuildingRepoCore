using Application.Common;

namespace Application.Cost;

public interface ICostTypeRepository:IGenericRepository<Domain.Cost.CostType>
{
    Domain.Cost.CostType GetbyCode(String Code);
}