using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Locations.Settlements.Towns;

public class TownData
{
    public static List<Town> TownList { get; private set; }

    public static void InitializeTownLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothSettlementTownJsonPath);
        var townDataJson = JsonConvert.DeserializeObject<TownList>(json);
        TownList = townDataJson.Towns;
    }
	
    public static void InitializeTownLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var townDataJson = JsonConvert.DeserializeObject<TownList>(json);
        TownList = townDataJson.Towns;
    }
    
    public static Town GetTownByName(string townName)
    {
        foreach (var town in TownList.Where(town => townName == town.Name))
        {
            return town;
        }

        throw new Exception("Cannot find town named: " + townName);
    }

    public static Location GetRandomTownLocationByWeight()
    {
        var townName = new List<string>();
        var townWeight = new List<int>();

        foreach (var town in TownList)
        {
            townName.Add(town.Name);
            townWeight.Add(town.Weight);
        }
        
        var random = new Random();
        var randomTownNumber = random.Next(1, townWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedTownName = null;

        for (var i = 0; i < townWeight.Count; i++)
        {
            cumulativeChance += townWeight[i];
            if (randomTownNumber <= cumulativeChance)
            {
                selectedTownName = townName[i];
                break;
            }
        }

        var targetTown = GetTownByName(selectedTownName);
#if DEBUG
        Console.WriteLine(targetTown.Name);
#endif
        return targetTown;
    }
}