namespace WanderlustTabletop.AppData.Locations.Hills.HillZones;

public class HillZone : Location
{
    public string HillName { get; set; }
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}