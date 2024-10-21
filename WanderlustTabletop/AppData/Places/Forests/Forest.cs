using Newtonsoft.Json;
using WanderlustTabletop.AppData.Places.Forests.ForestZones;

namespace WanderlustTabletop.AppData.Places.Forests;

public abstract class Forest : Location
{
    public string Name { get; set; }
    public List<ForestZone> Zones { get; set; }
    public int Id;
    public int Weight;
}
public class ForestList
{
    public List<Forest> Forests { get; set; }
}