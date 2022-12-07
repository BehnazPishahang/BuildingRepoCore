namespace Application.Cost;

public class Cost : GenericRepository<Domain.Building.Building>, Application.Building.IBuildingRepository
{

    public BuildingRepository(DataContext context) : base(context)
    {

    }
}