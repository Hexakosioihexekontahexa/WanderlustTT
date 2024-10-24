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