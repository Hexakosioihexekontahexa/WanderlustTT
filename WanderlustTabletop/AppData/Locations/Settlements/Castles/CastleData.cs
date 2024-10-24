using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Locations.Settlements.Castles;

public class CastleData
{
    public static List<Castle> CastleList { get; private set; }

    public static void InitializeCastleLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothSettlementCastleJsonPath);
        var castleDataJson = JsonConvert.DeserializeObject<CastleList>(json);
        CastleList = castleDataJson.Castles;
    }
	
    public static void InitializeCastleLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var castleDataJson = JsonConvert.DeserializeObject<CastleList>(json);
        CastleList = castleDataJson.Castles;
    }
    
    public static Castle GetCastleByName(string castleName)
    {
        foreach (var castle in CastleList.Where(castle => castleName == castle.Name))
        {
            return castle;
        }

        throw new Exception("Cannot find castle named: " + castleName);
    }

    public static Location GetRandomCastleLocationByWeight()
    {
        var castleName = new List<string>();
        var castleWeight = new List<int>();

        foreach (var castle in CastleList)
        {
            castleName.Add(castle.Name);
            castleWeight.Add(castle.Weight);
        }
        
        var random = new Random();
        var randomCastleNumber = random.Next(1, castleWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedCastleName = null;

        for (var i = 0; i < castleWeight.Count; i++)
        {
            cumulativeChance += castleWeight[i];
            if (randomCastleNumber <= cumulativeChance)
            {
                selectedCastleName = castleName[i];
                break;
            }
        }

        var targetCastle = GetCastleByName(selectedCastleName);
#if DEBUG
        Console.WriteLine(targetCastle.Name);
#endif
        return targetCastle;
    }
}