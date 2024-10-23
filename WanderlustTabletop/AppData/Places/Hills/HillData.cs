﻿using Newtonsoft.Json;
using WanderlustTabletop.AppData.Places.Hills.HillZones;

namespace WanderlustTabletop.AppData.Places.Hills;

public class HillData
{
    public static List<Hill> HillList { get; private set; }

    public static void InitializeHillLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothHillJsonPath);
        var hillDataJson = JsonConvert.DeserializeObject<HillList>(json);
        HillList = hillDataJson.Hills;
        HillZoneData.InitializeHillZones();
    }
	
    public static void InitializeHillLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var hillDataJson = JsonConvert.DeserializeObject<HillList>(json);
        HillList = hillDataJson.Hills;
        HillZoneData.InitializeHillZones();
    }
    
    public static Hill GetHillByName(string hillName)
    {
        foreach (var hill in HillList.Where(hill => hillName == hill.Name))
        {
            return hill;
        }

        throw new Exception("Cannot find hill named: " + hillName);
    }

    public static Location GetRandomHillLocationByWeight()
    {
        var hillName = new List<string>();
        var hillWeight = new List<int>();

        foreach (var hill in HillList)
        {
            hillName.Add(hill.Name);
            hillWeight.Add(hill.Weight);
        }
        
        var random = new Random();
        var randomHillNumber = random.Next(1, hillWeight.Sum() + 1);
        
        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedHillName = null;

        for (var i = 0; i < hillWeight.Count; i++)
        {
            cumulativeChance += hillWeight[i];
            if (randomHillNumber <= cumulativeChance)
            {
                selectedHillName = hillName[i];
                break;
            }
        }

        var targetHill = GetHillByName(selectedHillName);
        
        if (targetHill.Zones != null)
        {
            var totalHillZoneWeight = targetHill.Zones.Sum(zone => zone.Weight);

            if (random.Next(1, 11) >= 8) //30% success rate
            {
                var randomZoneNumber = random.Next(1, totalHillZoneWeight + 1);
                
                cumulativeChance = 0;
                string selectedHillZoneName = null;
                
                foreach (var hillZone in targetHill.Zones)
                {
                    cumulativeChance += hillZone.Weight;
                    if (randomZoneNumber <= cumulativeChance)
                    {
#if DEBUG
                        Console.WriteLine(hillZone.Name);
#endif
                        return HillZoneData.GetHillZoneByName(hillZone.Name);
                    }
                }
            }
        }
#if DEBUG
        Console.WriteLine(targetHill.Name);
#endif
        return targetHill;
    }
}