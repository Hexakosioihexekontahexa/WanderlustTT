namespace WanderlustTabletop.AppData.Menus;

public static class PlayerQtyMenu
{
    public static string PlayerQtyMenuHeader = "Пожалуйста, укажите количество игроков:";
    public static int PlayerQtySetting;
    private static readonly List<string> PlayerQtyOptionsList = new() { "1 Player", "2 Players", "3 Players", "4 Players" };
    public static MenuOptions PlayerQtyOptions = new MenuOptions(PlayerQtyOptionsList);
    private static bool _locker = false; 

    public static void DisplayPlayerQtyStartMenu()
    {
        _locker = true;
        do
        {
            Console.WriteLine(PlayerQtyMenuHeader);
            Menu.GenerateMenu(PlayerQtyOptions, new []{ "exit" });
            GetOptionData(Console.ReadLine());    
        } while (_locker);
        
    }
    
    public static void DisplayPlayerQtyOptionsMenu()
    {
        _locker = true;
        do
        {
            Console.WriteLine(PlayerQtyMenuHeader);
            Menu.GenerateMenu(PlayerQtyOptions, new []{ "back", "exit" });
            GetOptionData(Console.ReadLine(), "options");    
        } while (_locker);
    }
    
    public static void GetOptionData(string? option, string type = "start")
    {
        switch (option)
        {
            case "1":
                PlayerQtySetting = 1;
                _locker = false;
                break;
            case "2":
                PlayerQtySetting = 2;
                _locker = false;
                break;
            case "3":
                PlayerQtySetting = 3;
                _locker = false;
                break;
            case "4":
                PlayerQtySetting = 4;
                _locker = false;
                break;
            default:
                Menu.InvalidInput();
                break;
        }
    }
}