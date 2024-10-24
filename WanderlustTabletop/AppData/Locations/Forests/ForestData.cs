using Newtonsoft.Json;
using WanderlustTabletop.AppData.Locations.Forests.ForestZones;

namespace WanderlustTabletop.AppData.Locations.Forests;

public static class ForestData
{
    public static List<Forest> ForestList { get; private set; }

    public static void InitializeForestLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothForestJsonPath);
        var forestDataJson = JsonConvert.DeserializeObject<ForestList>(json);
        ForestList = forestDataJson.Forests;
        ForestZoneData.InitializeForestZones();
    }
	
    public static void InitializeForestLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var forestDataJson = JsonConvert.DeserializeObject<ForestList>(json);
        ForestList = forestDataJson.Forests;
        ForestZoneData.InitializeForestZones();
    }
    
    public static Forest GetForestByName(string forestName)
    {
        foreach (var forest in ForestList.Where(forest => forestName == forest.Name))
        {
            return forest;
        }

        throw new Exception("Cannot find forest named: " + forestName);
    }

    public static Location GetRandomForestLocationByWeight()
    {
        var forestName = new List<string>();
        var forestWeight = new List<int>();

        foreach (var forest in ForestList)
        {
            forestName.Add(forest.Name);
            forestWeight.Add(forest.Weight);
        }
        
        var random = new Random();
        var randomForestNumber = random.Next(1, forestWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedForestName = null;

        for (var i = 0; i < forestWeight.Count; i++)
        {
            cumulativeChance += forestWeight[i];
            if (randomForestNumber <= cumulativeChance)
            {
                selectedForestName = forestName[i];
                break;
            }
        }

        var targetForest = GetForestByName(selectedForestName);
        
        if (targetForest.Zones != null)
        {
            var totalForestZoneWeight = targetForest.Zones.Sum(zone => zone.Weight);

            if (random.Next(1, 11) >= 8) //30% success rate
            {
                var randomZoneNumber = random.Next(1, totalForestZoneWeight + 1);
                
                cumulativeChance = 0;
                string selectedForestZoneName = null;
                
                foreach (var forestZone in targetForest.Zones)
                {
                    cumulativeChance += forestZone.Weight;
                    if (randomZoneNumber <= cumulativeChance)
                    {
#if DEBUG
                        Console.WriteLine(forestZone.Name);
#endif
                        return ForestZoneData.GetForestZoneByName(forestZone.Name);
                    }
                }
            }
        }
#if DEBUG
        Console.WriteLine(targetForest.Name);
#endif
        return targetForest;
    }
}

 