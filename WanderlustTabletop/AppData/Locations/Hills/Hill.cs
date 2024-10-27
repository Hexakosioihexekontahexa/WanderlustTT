using WanderlustTabletop.AppData.Locations.Hills.HillZones;

namespace WanderlustTabletop.AppData.Locations.Hills;

public class Hill : Location
{
    public override string Name { get; set; }
    public new List<HillZone> Zones { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}

public class HillList
{
    public List<Hill>? Hills { get; set; }
}