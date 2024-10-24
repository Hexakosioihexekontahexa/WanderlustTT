using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Locations.Settlements.Sanctuaries;

public class SanctuaryData
{
    public static List<Sanctuary> SanctuaryList { get; private set; }

    public static void InitializeSanctuaryLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothSettlementSanctuaryJsonPath);
        var sanctuaryDataJson = JsonConvert.DeserializeObject<SanctuaryList>(json);
        SanctuaryList = sanctuaryDataJson.Sanctuaries;
    }
	
    public static void InitializeSanctuaryLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var sanctuaryDataJson = JsonConvert.DeserializeObject<SanctuaryList>(json);
        SanctuaryList = sanctuaryDataJson.Sanctuaries;
    }
    
    public static Sanctuary GetSanctuaryByName(string sanctuaryName)
    {
        foreach (var sanctuary in SanctuaryList.Where(sanctuary => sanctuaryName == sanctuary.Name))
        {
            return sanctuary;
        }

        throw new Exception("Cannot find sanctuary named: " + sanctuaryName);
    }

    public static Location GetRandomSanctuaryLocationByWeight()
    {
        var sanctuaryName = new List<string>();
        var sanctuaryWeight = new List<int>();

        foreach (var sanctuary in SanctuaryList)
        {
            sanctuaryName.Add(sanctuary.Name);
            sanctuaryWeight.Add(sanctuary.Weight);
        }
        
        var random = new Random();
        var randomSanctuaryNumber = random.Next(1, sanctuaryWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedSanctuaryName = null;

        for (var i = 0; i < sanctuaryWeight.Count; i++)
        {
            cumulativeChance += sanctuaryWeight[i];
            if (randomSanctuaryNumber <= cumulativeChance)
            {
                selectedSanctuaryName = sanctuaryName[i];
                break;
            }
        }

        var targetSanctuary = GetSanctuaryByName(selectedSanctuaryName);
#if DEBUG
        Console.WriteLine(targetSanctuary.Name);
#endif
        return targetSanctuary;
    }
}