namespace WanderlustTabletop.AppData.Locations.Plains.PlainZones;

public class PlainZoneData
{
    public static List<PlainZone> PlainZoneList = new();
    
    public static void InitializePlainZones()
    {
        foreach (var plain in PlainData.PlainList)
        {
            if (plain.Zones != null)
            {
                foreach (var plainZone in plain.Zones)
                {
                    plainZone.PlainName = plain.Name;
                    PlainZoneList.Add(plainZone);
                }
            }
        }
    }

    public static PlainZone GetPlainZoneByName(string plainZoneName)
    {
        return PlainZoneList.Where(zone => plainZoneName == zone.Name).FirstOrDefault();
    }

    public static Location GetPlainZoneChanceByWeightAndTargetPlain(Plain targetPlain)
    {
        if (targetPlain.Name == "Uncategorized")
        {
            var debug = 1;
        }
        var random = new Random();
        var totalPlainZoneWeight = targetPlain.Zones.Sum(zone => zone.Weight);

        if (random.Next(1, 11) >= 8) //30% success rate
        {
            var randomZoneNumber = random.Next(1, totalPlainZoneWeight + 1);
                
            var cumulativeChance = 0;
            string selectedPlainZoneName = null;
                
            foreach (var plainZone in targetPlain.Zones)
            {
                cumulativeChance += plainZone.Weight;
                if (randomZoneNumber <= cumulativeChance)
                {
#if DEBUG
                        Console.WriteLine(plainZone.Name);
#endif
                    return GetPlainZoneByName(plainZone.Name);
                }
            }
        }

        return targetPlain;
    }
    
    public static PlainZone GetPlainZoneByWeightAndTargetPlain(Plain targetPlain)
    {
        var totalPlainZoneWeight = targetPlain.Zones.Sum(zone => zone.Weight);
        var random = new Random();
        var randomZoneNumber = random.Next(1, totalPlainZoneWeight + 1);
            
        var cumulativeChance = 0;
        string selectedPlainZoneName = null;
            
        foreach (var plainZone in targetPlain.Zones)
        {
            cumulativeChance += plainZone.Weight;
            if (randomZoneNumber <= cumulativeChance)
            {
#if DEBUG
                    Console.WriteLine(plainZone.Name);
#endif
                selectedPlainZoneName = plainZone.Name;
                break;
            }
        }
        

        return GetPlainZoneByName(selectedPlainZoneName);
    }

    public static List<PlainZone> GetPlainZoneList(Plain plain)
    {
        return plain.Zones.Where(zone => zone != null).ToList();
    }

    public static PlainZone GetPlainZoneByNameFromPlain(string plainZoneName, string plainName)
    {
        return PlainData.GetPlainByName(plainName).Zones.
            Where(plainZone => plainZone.Name == plainZoneName).FirstOrDefault();
    }
}