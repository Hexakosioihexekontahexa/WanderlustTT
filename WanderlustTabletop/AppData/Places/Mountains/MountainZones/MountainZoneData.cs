namespace WanderlustTabletop.AppData.Places.Mountains.MountainZones;

public class MountainZoneData
{
    public static List<MountainZone> MountainZoneList = new();
    
    public static void InitializeMountainZones()
    {
        foreach (var mountain in MountainData.MountainList)
        {
            if (mountain.Zones != null)
            {
                foreach (var mountainZone in mountain.Zones)
                {
                    mountainZone.MountainName = mountain.Name;
                    MountainZoneList.Add(mountainZone);
                }
            }
        }
    }

    public static MountainZone GetMountainZoneByName(string mountainZoneName)
    {
        return MountainZoneList.Where(zone => mountainZoneName == zone.Name).FirstOrDefault();
    }

    public static List<MountainZone> GetMountainZoneList(Mountain mountain)
    {
        return mountain.Zones.Where(zone => zone != null).ToList();
    }

    public static MountainZone GetMountainZoneByNameFromMountain(string mountainZoneName, string mountainName)
    {
        return MountainData.GetMountainByName(mountainName).Zones.
            Where(mountainZone => mountainZone.Name == mountainZoneName).FirstOrDefault();
    }
}