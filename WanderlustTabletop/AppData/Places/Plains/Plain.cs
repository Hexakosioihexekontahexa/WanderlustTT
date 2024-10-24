using WanderlustTabletop.AppData.Places.Plains.PlainZones;

namespace WanderlustTabletop.AppData.Places.Plains;

public class Plain : Location
{
    public new string Name { get; set; }
    public new List<PlainZone> Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class PlainList
{
    public List<Plain> Plains { get; set; }
}