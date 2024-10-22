using WanderlustTabletop.AppData;
using WanderlustTabletop.AppData.Menus;
using WanderlustTabletop.AppData.Places.Forests;

namespace WanderlustTabletop;

public abstract class Program
{
    public static void Main(string[] args)
    {
        //var test = new ForestContainer();
        DataLoader.InitializeResources();
        //PlayerQtyMenu.DisplayPlayerQtyStartMenu();
        //ForestData.GetForestByName("Древо горя");
        for (int i = 0; i < 50; i++)
        {
            ForestData.GetRandomForestLocationByWeight();    
        }
    }    
}