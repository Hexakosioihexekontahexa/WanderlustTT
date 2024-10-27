namespace WanderlustTabletop.AppData.Locations.Mountains.MountainZones;

public class MountainZone : Location
{
    public string MountainName { get; set; }
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}