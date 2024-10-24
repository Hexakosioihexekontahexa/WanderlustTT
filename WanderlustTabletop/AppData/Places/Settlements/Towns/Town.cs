namespace WanderlustTabletop.AppData.Places.Settlements.Towns;

public class Town : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class TownList
{
    public List<Town> Towns { get; set; }
}