namespace WanderlustTabletop.AppData.Places.Hills.HillZones;

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