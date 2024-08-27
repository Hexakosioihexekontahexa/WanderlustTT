using WanderlustTabletop.AppData.Worlds;

namespace WanderlustTabletop.AppData.Menus;

public class WorldSelectionMenu
{
    public static string WorldSelectionMenuHeader = "Пожалуйста, укажите количество игроков:";
    public static World WorldSelectionSetting;
    private static readonly List<string> PlayerQtyOptionsList = new List<string> { "1 Player", "2 Players", "3 Players", "4 Players" };
    public static MenuOptions PlayerQtyOptions = new MenuOptions(PlayerQtyOptionsList);
    private static bool _locker = false; 
}