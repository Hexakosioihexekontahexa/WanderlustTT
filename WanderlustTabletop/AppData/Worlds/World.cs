using WanderlustTabletop.AppData.Locations;
using WanderlustTabletop.AppData.Locations.Forests;
using WanderlustTabletop.AppData.Locations.Hills;
using WanderlustTabletop.AppData.Locations.Lakes;
using WanderlustTabletop.AppData.Locations.Mountains;
using WanderlustTabletop.AppData.Locations.Plains;
using WanderlustTabletop.AppData.Locations.Settlements.Castles;
using WanderlustTabletop.AppData.Locations.Settlements.Sanctuaries;
using WanderlustTabletop.AppData.Locations.Settlements.Towns;
using WanderlustTabletop.AppData.Locations.Settlements.Villages;
using WanderlustTabletop.AppData.Locations.Swamps;

namespace WanderlustTabletop.AppData.Worlds;

public class World
{
    public int Id;
    public string WorldName;
    public List<Forest> Forests;
    public List<Hill> Hills;
    public List<Lake> Lakes;
    public List<Mountain> Mountains;
    public List<Plain> Plains;
    public List<Swamp> Swamps;
    //private List<string> Settlements;
    public List<Castle> Castles;
    public List<Sanctuary> Sanctuaries;
    public List<Town> Towns;
    public List<Village> Villages;

    //public Questpack questpack; 
    
    public World(int id, string worldName, List<Forest> forestList, List<Hill> hillList, List<Lake> lakeList,
        List<Mountain> mountainList, List<Plain> plainList, List<Swamp> swampList, List<Castle> castleList, 
        List<Sanctuary> sanctuaryList, List<Town> townList, List<Village> villageList)
    {
        Id = id;
        WorldName = worldName;
        Forests = forestList;
        Hills = hillList;
        Lakes = lakeList;
        Mountains = mountainList;
        Plains = plainList;
        Swamps = swampList;
        Castles = castleList;
        Sanctuaries = sanctuaryList;
        Towns = townList;
        Villages = villageList;
    }
}