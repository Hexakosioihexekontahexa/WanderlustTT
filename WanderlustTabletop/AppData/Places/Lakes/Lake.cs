namespace WanderlustTabletop.AppData.Places.Lakes;

public class Lake : Location
{
    public new string Name { get; set; }
    public new int Id { get; set; }
    public new int Weight { get; set; }
}

public class LakeList
{
    public List<Lake> Lakes { get; set; }
}