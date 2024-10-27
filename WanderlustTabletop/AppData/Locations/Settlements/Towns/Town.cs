namespace WanderlustTabletop.AppData.Locations.Settlements.Towns;

public class Town : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class TownList
{
    public List<Town> Towns { get; set; }
}