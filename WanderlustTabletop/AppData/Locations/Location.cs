namespace WanderlustTabletop.AppData.Locations;

public abstract class Location
{
    public string Name { get; set; }
    public List<Location> Zones { get; set; }
    public int Id { get; set; }
    public int Weight { get; set; }
}