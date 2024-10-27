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

namespace WanderlustTabletop.AppData.Locations;

public class Location
{
    public virtual string Name { get; set; }
    public List<Location> Zones { get; set; }
    public int Id { get; set; }
    public int Weight { get; set; }
    public int CategoryWeight { get; set; }

    public static Location GetRandomLocationByWeight()
    {
        var targetLocation = new Location();
        var locationCategoryWeightDictionary = new Dictionary<string, int>
        {
            { "forest", ForestData.ForestList.Count },
            { "hill", HillData.HillList.Count },
            { "lake", LakeData.LakeList.Count },
            { "mount", MountainData.MountainList.Count },
            { "plain", PlainData.PlainList.Count },
            { "swamp", SwampData.SwampList.Count },
            { "castle", CastleData.CastleList.Count },
            { "sanct", SanctuaryData.SanctuaryList.Count },
            { "town", TownData.TownList.Count },
            { "village", VillageData.VillageList.Count }
        };

        var cumulativeChance = 0;
        var randomNumber = new Random().Next(1, locationCategoryWeightDictionary.Values.Sum() + 1);
        
        for (var i = 0; i < locationCategoryWeightDictionary.Count; i++)
        {
            cumulativeChance += locationCategoryWeightDictionary.Skip(i).First().Value;
            
            if (randomNumber <= cumulativeChance)
            {
                targetLocation = GetRandomLocationByType(locationCategoryWeightDictionary.Skip(i).First().Key);
                break;
            }
        }
        
        return targetLocation;
    }
    
    public static Location GetLocationByName(string type, string locationName)
    {
        var result = type.ToLower() switch
        {
            "forest" => (Location)ForestData.GetForestByName(locationName),
            "hill" => HillData.GetHillByName(locationName),
            "lake" => LakeData.GetLakeByName(locationName),
            "mount" => MountainData.GetMountainByName(locationName),
            "plain" => PlainData.GetPlainByName(locationName),
            "swamp" => SwampData.GetSwampByName(locationName),
            "castle" => CastleData.GetCastleByName(locationName),
            "sanct" => SanctuaryData.GetSanctuaryByName(locationName),
            "town" => TownData.GetTownByName(locationName),
            "village" => VillageData.GetVillageByName(locationName),
            _ => throw new Exception($"There's no type: {type}.")
        };

        return result;
    }

    public static Location GetRandomLocationByType(string type)
    {
        var result = type.ToLower() switch
        {
            "forest" => ForestData.GetRandomForestLocationByWeight(),
            "hill" => HillData.GetRandomHillLocationByWeight(),
            "lake" => LakeData.GetRandomLakeLocationByWeight(),
             "mount" => MountainData.GetRandomMountainLocationByWeight(),
             "plain" => PlainData.GetRandomPlainLocationByWeight(),
             "swamp" => SwampData.GetRandomSwampLocationByWeight(),
             "castle" => CastleData.GetRandomCastleLocationByWeight(),
             "sanct" => SanctuaryData.GetRandomSanctuaryLocationByWeight(),
             "town" => TownData.GetRandomTownLocationByWeight(),
            "village" => VillageData.GetRandomVillageLocationByWeight(),
            _ => throw new Exception($"There's no type: {type}.")
        };

        return result;
    }
}