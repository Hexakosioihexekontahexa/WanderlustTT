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

namespace WanderlustTabletop.AppData;

public abstract class DataLoader
{
    public static void InitializeResources()
    {
        ForestData.InitializeForestLocations();
        HillData.InitializeHillLocations();
        LakeData.InitializeLakeLocations();
        MountainData.InitializeMountainLocations();
        PlainData.InitializePlainLocations();
        SwampData.InitializeSwampLocations();
        CastleData.InitializeCastleLocations();
        SanctuaryData.InitializeSanctuaryLocations();
        TownData.InitializeTownLocations();
        VillageData.InitializeVillageLocations();
    } 
}