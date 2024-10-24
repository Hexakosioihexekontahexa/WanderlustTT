namespace WanderlustTabletop.AppData.Locations.Swamps;

public class Swamp : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class SwampList
{
    public List<Swamp> Swamps { get; set; }
}