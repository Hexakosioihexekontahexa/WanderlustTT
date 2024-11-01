﻿namespace WanderlustTabletop.AppData.Locations.Hills.HillZones;

public class HillZoneData
{
    public static List<HillZone> HillZoneList = new();
    
    public static void InitializeHillZones()
    {
        foreach (var hill in HillData.HillList)
        {
            if (hill.Zones != null)
            {
                foreach (var hillZone in hill.Zones)
                {
                    hillZone.HillName = hill.Name;
                    HillZoneList.Add(hillZone);
                }
            }
        }
    }

    public static HillZone GetHillZoneByName(string hillZoneName)
    {
        return HillZoneList.Where(zone => hillZoneName == zone.Name).FirstOrDefault();
    }

    
    
    public static Location GetHillZoneChanceByWeightAndTargetHill(Hill targetHill)
    {
        if (targetHill.Name == "Uncategorized")
        {
            var debug = 1;
        }
        var random = new Random();
        var totalHillZoneWeight = targetHill.Zones.Sum(zone => zone.Weight);

        if (random.Next(1, 11) >= 8) //30% success rate
        {
            var randomZoneNumber = random.Next(1, totalHillZoneWeight + 1);
                
            var cumulativeChance = 0;
            string selectedHillZoneName = null;
                
            foreach (var hillZone in targetHill.Zones)
            {
                cumulativeChance += hillZone.Weight;
                if (randomZoneNumber <= cumulativeChance)
                {
#if DEBUG
                        Console.WriteLine(hillZone.Name);
#endif
                    return GetHillZoneByName(hillZone.Name);
                }
            }
        }

        return targetHill;
    }
    
    public static HillZone GetHillZoneByWeightAndTargetHill(Hill targetHill)
    {
        var totalHillZoneWeight = targetHill.Zones.Sum(zone => zone.Weight);
        var random = new Random();
        var randomZoneNumber = random.Next(1, totalHillZoneWeight + 1);
            
        var cumulativeChance = 0;
        string selectedHillZoneName = null;
            
        foreach (var hillZone in targetHill.Zones)
        {
            cumulativeChance += hillZone.Weight;
            if (randomZoneNumber <= cumulativeChance)
            {
#if DEBUG
                    Console.WriteLine(hillZone.Name);
#endif
                selectedHillZoneName = hillZone.Name;
                break;
            }
        }
        

        return GetHillZoneByName(selectedHillZoneName);
    }
    
    
    
    public static List<HillZone> GetHillZoneList(Hill hill)
    {
        return hill.Zones.Where(zone => zone != null).ToList();
    }

    public static HillZone GetHillZoneByNameFromHill(string hillZoneName, string hillName)
    {
        return HillData.GetHillByName(hillName).Zones.
            Where(hillZone => hillZone.Name == hillZoneName).FirstOrDefault();
    }
}