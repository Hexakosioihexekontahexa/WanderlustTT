using WanderlustTabletop.AppData.Locations.Forests.ForestZones;

namespace WanderlustTabletop.AppData.Locations.Forests;

public class Forest : Location
{
    public override string Name { get; set; }
    public new List<ForestZone>? Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class ForestList
{
    public List<Forest>? Forests { get; set; }
}