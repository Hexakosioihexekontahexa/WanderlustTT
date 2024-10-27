namespace WanderlustTabletop.AppData.Locations.Settlements.Sanctuaries;

public class Sanctuary : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class SanctuaryList
{
    public List<Sanctuary> Sanctuaries { get; set; }
}