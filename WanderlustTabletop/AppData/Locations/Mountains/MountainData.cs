using Newtonsoft.Json;
using WanderlustTabletop.AppData.Locations.Mountains.MountainZones;

namespace WanderlustTabletop.AppData.Locations.Mountains;

public class MountainData
{
    public static List<Mountain> MountainList { get; private set; }

    public static void InitializeMountainLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothMountainJsonPath);
        var mountainDataJson = JsonConvert.DeserializeObject<MountainList>(json);
        MountainList = mountainDataJson.Mountains;
        MountainZoneData.InitializeMountainZones();
    }
	
    public static void InitializeMountainLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var mountainDataJson = JsonConvert.DeserializeObject<MountainList>(json);
        MountainList = mountainDataJson.Mountains;
        MountainZoneData.InitializeMountainZones();
    }
    
    public static Mountain GetMountainByName(string mountainName)
    {
        foreach (var mountain in MountainList.Where(mountain => mountainName == mountain.Name))
        {
            return mountain;
        }

        throw new Exception("Cannot find mountain named: " + mountainName);
    }

    public static Location GetRandomMountainLocationByWeight()
    {
        var mountainName = new List<string>();
        var mountainWeight = new List<int>();

        foreach (var mountain in MountainList)
        {
            mountainName.Add(mountain.Name);
            mountainWeight.Add(mountain.Weight);
        }
        
        var random = new Random();
        var randomMountainNumber = random.Next(1, mountainWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedMountainName = null;

        for (var i = 0; i < mountainWeight.Count; i++)
        {
            cumulativeChance += mountainWeight[i];
            if (randomMountainNumber <= cumulativeChance)
            {
                selectedMountainName = mountainName[i];
                break;
            }
        }

        var targetMountain = GetMountainByName(selectedMountainName);
        
        if (targetMountain.Zones != null)
        {
            var totalMountainZoneWeight = targetMountain.Zones.Sum(zone => zone.Weight);

            if (random.Next(1, 11) >= 8) //30% success rate
            {
                var randomZoneNumber = random.Next(1, totalMountainZoneWeight + 1);
                
                cumulativeChance = 0;
                string selectedMountainZoneName = null;
                
                foreach (var mountainZone in targetMountain.Zones)
                {
                    cumulativeChance += mountainZone.Weight;
                    if (randomZoneNumber <= cumulativeChance)
                    {
#if DEBUG
                        Console.WriteLine(mountainZone.Name);
#endif
                        return MountainZoneData.GetMountainZoneByName(mountainZone.Name);
                    }
                }
            }
        }
#if DEBUG
        Console.WriteLine(targetMountain.Name);
#endif
        return targetMountain;
    }
}