namespace WanderlustTabletop.AppData.Places.Settlements.Villages;

public class Village : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}
public class VillageList
{
    public List<Village> Villages { get; set; }
}