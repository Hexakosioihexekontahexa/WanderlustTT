using WanderlustTabletop.AppData.Menus;
using WanderlustTabletop.AppData.Places.Forests;

namespace WanderlustTabletop;

public abstract class Program
{
    public static void Main(string[] args)
    {
        //var test = new ForestContainer();
        ForestContainer.InitializeForests();
        //PlayerQtyMenu.DisplayPlayerQtyStartMenu();
    }    
}