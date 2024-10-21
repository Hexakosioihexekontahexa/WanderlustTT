using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Places.Forests.ForestZones;

public class ForestZoneData
{
    public static void InitializeForestZones()
    {
        const string forestJsonPath = "AppData/Places/Forests/Forests.json";
        var json = File.ReadAllText(forestJsonPath);
        var forestZoneDataJson = JsonConvert.DeserializeObject<ForestZoneList>(json);
        ForestZoneList = forestZoneDataJson.ForestZones;
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
}