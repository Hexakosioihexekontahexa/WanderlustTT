using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Locations.Swamps;

public class SwampData
{
    public static List<Swamp> SwampList { get; private set; }

    public static void InitializeSwampLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothSwampJsonPath);
        var swampDataJson = JsonConvert.DeserializeObject<SwampList>(json);
        SwampList = swampDataJson.Swamps;
    }
	
    public static void InitializeSwampLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var swampDataJson = JsonConvert.DeserializeObject<SwampList>(json);
        SwampList = swampDataJson.Swamps;
    }
    
    public static Swamp GetSwampByName(string swampName)
    {
        foreach (var swamp in SwampList.Where(swamp => swampName == swamp.Name))
        {
            return swamp;
        }

        throw new Exception("Cannot find swamp named: " + swampName);
    }

    public static Location GetRandomSwampLocationByWeight()
    {
        var swampName = new List<string>();
        var swampWeight = new List<int>();

        foreach (var swamp in SwampList)
        {
            swampName.Add(swamp.Name);
            swampWeight.Add(swamp.Weight);
        }
        
        var random = new Random();
        var randomSwampNumber = random.Next(1, swampWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedSwampName = null;

        for (var i = 0; i < swampWeight.Count; i++)
        {
            cumulativeChance += swampWeight[i];
            if (randomSwampNumber <= cumulativeChance)
            {
                selectedSwampName = swampName[i];
                break;
            }
        }

        var targetSwamp = GetSwampByName(selectedSwampName);
#if DEBUG
        Console.WriteLine(targetSwamp.Name);
#endif
        return targetSwamp;
    }
}