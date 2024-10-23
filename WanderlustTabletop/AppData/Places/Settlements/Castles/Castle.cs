namespace WanderlustTabletop.AppData.Places.Settlements.Castles;

public class Castle : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class CastleList
{
    public List<Castle> Castles { get; set; }
}