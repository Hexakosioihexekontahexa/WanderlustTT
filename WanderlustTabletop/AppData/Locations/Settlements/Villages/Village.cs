namespace WanderlustTabletop.AppData.Locations.Settlements.Villages;

public class Village : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}
public class VillageList
{
    public List<Village> Villages { get; set; }
}