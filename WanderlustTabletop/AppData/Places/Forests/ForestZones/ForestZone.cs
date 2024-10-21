namespace WanderlustTabletop.AppData.Places.Forests.ForestZones;

public class ForestZone : Location
{
    public string Name { get; set; }
    public int Id;
    public int Weight;
}

public class ForestZoneList
{
    public List<ForestZone> ForestZones { get; set; }
}