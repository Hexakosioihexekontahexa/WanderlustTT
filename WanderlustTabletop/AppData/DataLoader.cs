using WanderlustTabletop.AppData.Places.Forests;

namespace WanderlustTabletop.AppData;

public abstract class DataLoader
{
    public static void InitializeResources()
    {
        ForestData.InitializeForestLocations();
    } 
}