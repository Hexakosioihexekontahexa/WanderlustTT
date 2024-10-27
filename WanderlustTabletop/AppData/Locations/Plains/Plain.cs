using WanderlustTabletop.AppData.Locations.Plains.PlainZones;

namespace WanderlustTabletop.AppData.Locations.Plains;

public class Plain : Location
{
    public override string Name { get; set; }
    public new List<PlainZone> Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class PlainList
{
    public List<Plain> Plains { get; set; }
}