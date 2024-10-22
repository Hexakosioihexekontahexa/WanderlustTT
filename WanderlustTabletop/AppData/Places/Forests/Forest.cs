using Newtonsoft.Json;
using WanderlustTabletop.AppData.Places.Forests.ForestZones;

namespace WanderlustTabletop.AppData.Places.Forests;

public class Forest : Location
{
    public string Name { get; set; }
    public List<ForestZone> Zones { get; set; }
    public int Id { get; set; }
    public int Weight { get; set; }
}
public class ForestList
{
    public List<Forest> Forests { get; set; }
}