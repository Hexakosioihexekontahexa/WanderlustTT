namespace WanderlustTabletop.AppData.Locations.Forests.ForestZones;

public static class ForestZoneData
{
    public static List<ForestZone> ForestZoneList = new();
    
    public static void InitializeForestZones()
    {
        foreach (var forest in ForestData.ForestList)
        {
            if (forest.Zones != null)
            {
                foreach (var forestZone in forest.Zones)
                {
                    forestZone.ForestName = forest.Name;
                    ForestZoneList.Add(forestZone);
                }
            }
        }
    }

    public static ForestZone GetForestZoneByName(string forestZoneName)
    {
        return ForestZoneList.Where(zone => forestZoneName == zone.Name).FirstOrDefault();
    }

    public static List<ForestZone> GetForestZoneList(Forest forest)
    {
        return forest.Zones.Where(zone => zone != null).ToList();
    }

    public static ForestZone GetForestZoneByNameFromForest(string forestZoneName, string forestName)
    {
        return ForestData.GetForestByName(forestName).Zones.
            Where(forestZone => forestZone.Name == forestZoneName).FirstOrDefault();
    }
}