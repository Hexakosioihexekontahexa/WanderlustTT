using WanderlustTabletop.AppData.Locations.Mountains.MountainZones;

namespace WanderlustTabletop.AppData.Locations.Mountains;

public class Mountain : Location
{
    public new string Name { get; set; }
    public new List<MountainZone> Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class MountainList
{
    public List<Mountain> Mountains { get; set; }
}