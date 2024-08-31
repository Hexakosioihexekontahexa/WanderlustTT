namespace WanderlustTabletop.AppData.Worlds;

public abstract class World
{
    private int count;
    public string worldName;
    private List<string> Forests;
    private List<string> Hills;
    private List<string> Lakes;
    private List<string> Mountains;
    private List<string> Plains;
    private List<string> Swamps;
    private List<string> Settlements;
    // private List<string> Towns;
    // private List<string> Sanctuaries;
    // private List<string> Castles;
    // private List<string> Villages;

    //public Questpack questpack; 
    
    public World(int count, string worldName)
    {
        this.count = count;
        this.worldName = worldName;
    }
}