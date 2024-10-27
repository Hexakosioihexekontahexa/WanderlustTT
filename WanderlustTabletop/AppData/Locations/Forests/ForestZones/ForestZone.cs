namespace WanderlustTabletop.AppData.Locations.Forests.ForestZones;

public class ForestZone : Location
{
    public string ForestName { get; set; }
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}