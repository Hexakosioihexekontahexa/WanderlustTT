using WanderlustTabletop.AppData;
using WanderlustTabletop.AppData.Locations;
using WanderlustTabletop.AppData.Locations.Forests;
using WanderlustTabletop.AppData.Locations.Hills;
using WanderlustTabletop.AppData.Locations.Lakes;
using WanderlustTabletop.AppData.Locations.Mountains;
using WanderlustTabletop.AppData.Locations.Plains;
using WanderlustTabletop.AppData.Locations.Settlements.Castles;
using WanderlustTabletop.AppData.Locations.Settlements.Sanctuaries;
using WanderlustTabletop.AppData.Locations.Settlements.Towns;
using WanderlustTabletop.AppData.Locations.Settlements.Villages;
using WanderlustTabletop.AppData.Locations.Swamps;
using WanderlustTabletop.AppData.Menus;
using WanderlustTabletop.AppData.Worlds;

namespace WanderlustTabletop;

public abstract class Program
{
    public static void Main(string[] args)
    {
        //var test = new ForestContainer();
        DataLoader.InitializeResources();
        Statistics.Run();
    }    
}