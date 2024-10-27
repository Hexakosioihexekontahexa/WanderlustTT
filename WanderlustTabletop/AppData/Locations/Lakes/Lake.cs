namespace WanderlustTabletop.AppData.Locations.Lakes;

public class Lake : Location
{
    public override string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
    public new static int CategoryWeight = 10;
}

public class LakeList
{
    public List<Lake>? Lakes { get; set; }
}