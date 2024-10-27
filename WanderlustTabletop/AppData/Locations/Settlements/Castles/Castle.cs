namespace WanderlustTabletop.AppData.Locations.Settlements.Castles;

public class Castle : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class CastleList
{
    public List<Castle>? Castles { get; set; }
}