namespace WanderlustTabletop.AppData.Locations.Swamps;

public class Swamp : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class SwampList
{
    public List<Swamp>? Swamps { get; set; }
}