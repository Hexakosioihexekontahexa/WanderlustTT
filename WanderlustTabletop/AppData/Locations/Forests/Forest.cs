using WanderlustTabletop.AppData.Locations.Forests.ForestZones;

namespace WanderlustTabletop.AppData.Locations.Forests;

public class Forest : Location
{
    public new string Name { get; set; }
    public new List<ForestZone> Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class ForestList
{
    public List<Forest> Forests { get; set; }
}