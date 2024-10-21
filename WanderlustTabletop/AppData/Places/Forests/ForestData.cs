using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Places.Forests;

public static class ForestData
{
    public static List<Forest> ForestList { get; private set; }

    public static void InitializeForests()
    {
        const string forestJsonPath = "AppData/Places/Forests/Forests.json";
        var json = File.ReadAllText(forestJsonPath);
        var forestDataJson = JsonConvert.DeserializeObject<ForestList>(json);
        ForestList = forestDataJson.Forests;
    }
	
    public static void InitializeForests(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var forestDataJson = JsonConvert.DeserializeObject<ForestList>(json);
        ForestList = forestDataJson.Forests;
    }
    
    public static Forest GetForestByName(string forestName)
    {
        foreach (var forest in ForestList.Where(forest => forestName == forest.Name))
        {
            return forest;
        }

        throw new Exception("Cannot find forest named: " + forestName);
    }

    public static Location GetRandomForestByWeight()
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
        var forestZone = new List<string>();
        var forestZoneWeight = new List<int>();
        
        if (targetForest.Zones != null)
        {
            foreach (var zone in targetForest.Zones)
            {
                forestZone.Add(zone.Name);
                forestZoneWeight.Add(zone.Weight);
            }

            if (random.Next(1, 11) == 10)
            {
                var randomZoneNumber = random.Next(1, forestZoneWeight.Sum() + 1);
                
                cumulativeChance = 0;
                string selectedForestZoneName = null;
                
                for (var i = 0; i < forestZoneWeight.Count; i++)
                {
                    cumulativeChance += forestZoneWeight[i];
                    if (randomZoneNumber <= cumulativeChance)
                    {
                        return 
                        //selectedForestZoneName = forestZone[i];
                        break;
                    }
                }
            }
            
            
        }

        return targetForest;
        throw new Exception("Forest randomization failed" + forestName);
        //return ForestList[0];
    }
}

 