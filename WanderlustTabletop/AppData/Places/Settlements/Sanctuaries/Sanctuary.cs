namespace WanderlustTabletop.AppData.Places.Settlements.Sanctuaries;

public class Sanctuary : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class SanctuaryList
{
    public List<Sanctuary> Sanctuaries { get; set; }
}