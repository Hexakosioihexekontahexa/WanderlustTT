using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Locations.Settlements.Villages;

public class VillageData
{
    public static List<Village> VillageList { get; private set; }

    public static void InitializeVillageLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothSettlementVillageJsonPath);
        var villageDataJson = JsonConvert.DeserializeObject<VillageList>(json);
        VillageList = villageDataJson.Villages;
    }
	
    public static void InitializeVillageLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var villageDataJson = JsonConvert.DeserializeObject<VillageList>(json);
        VillageList = villageDataJson.Villages;
    }
    
    public static Village GetVillageByName(string villageName)
    {
        foreach (var village in VillageList.Where(village => villageName == village.Name))
        {
            return village;
        }

        throw new Exception("Cannot find village named: " + villageName);
    }

    public static Location GetRandomVillageLocationByWeight()
    {
        var villageName = new List<string>();
        var villageWeight = new List<int>();

        foreach (var village in VillageList)
        {
            villageName.Add(village.Name);
            villageWeight.Add(village.Weight);
        }
        
        var random = new Random();
        var randomVillageNumber = random.Next(0, villageWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedVillageName = null;

        for (var i = 0; i < villageWeight.Count; i++)
        {
            cumulativeChance += villageWeight[i];
            if (randomVillageNumber <= cumulativeChance)
            {
                selectedVillageName = villageName[i];
                break;
            }
        }

        var targetVillage = GetVillageByName(selectedVillageName);
#if DEBUG
        Console.WriteLine(targetVillage.Name);
#endif
        return targetVillage;
    }
}