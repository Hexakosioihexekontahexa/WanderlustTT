using WanderlustTabletop.AppData.Menus;
using WanderlustTabletop.AppData.Places.Forests;

namespace WanderlustTabletop;

public abstract class Program
{
    public static void Main(string[] args)
    {
        //var test = new ForestContainer();
        ForestData.InitializeForests();
        //PlayerQtyMenu.DisplayPlayerQtyStartMenu();
        ForestData.GetForestByName("Древо горя");
    }    
}