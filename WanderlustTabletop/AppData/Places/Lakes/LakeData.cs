using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Places.Lakes;

public class LakeData
{
    public static List<Lake> LakeList { get; private set; }

    public static void InitializeLakeLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothLakeJsonPath);
        var lakeDataJson = JsonConvert.DeserializeObject<LakeList>(json);
        LakeList = lakeDataJson.Lakes;
    }
	
    public static void InitializeLakeLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var lakeDataJson = JsonConvert.DeserializeObject<LakeList>(json);
        LakeList = lakeDataJson.Lakes;
    }
    
    public static Lake GetLakeByName(string lakeName)
    {
        foreach (var lake in LakeList.Where(lake => lakeName == lake.Name))
        {
            return lake;
        }

        throw new Exception("Cannot find lake named: " + lakeName);
    }

    public static Location GetRandomLakeLocationByWeight()
    {
        var lakeName = new List<string>();
        var lakeWeight = new List<int>();

        foreach (var lake in LakeList)
        {
            lakeName.Add(lake.Name);
            lakeWeight.Add(lake.Weight);
        }
        
        var random = new Random();
        var randomLakeNumber = random.Next(1, lakeWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedLakeName = null;

        for (var i = 0; i < lakeWeight.Count; i++)
        {
            cumulativeChance += lakeWeight[i];
            if (randomLakeNumber <= cumulativeChance)
            {
                selectedLakeName = lakeName[i];
                break;
            }
        }

        var targetLake = GetLakeByName(selectedLakeName);
#if DEBUG
        Console.WriteLine(targetLake.Name);
#endif
        return targetLake;
    }
}