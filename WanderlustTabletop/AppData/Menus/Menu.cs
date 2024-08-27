namespace WanderlustTabletop.AppData.Menus;

public static class Menu
{
    public static void GenerateMenu(MenuOptions options, string[] args, int page = 0)
    {
        var pageItemQty = (options.Count() - page * 9) % 9;
        
        for (var item = 1; item <= pageItemQty + 1; item++)
        {
            if (item == pageItemQty + 1)
            {
                if (args.Contains("back"))
                {
                    Console.WriteLine("b. Back");                    
                }
                        
                if (args.Contains("options"))
                {
                    Console.WriteLine("0. Options");                    
                }
                        
                if (args.Contains("exit"))
                {
                    Console.WriteLine("e. Exit");                    
                }
            }
            else
            {
                Console.WriteLine(item + ". " + options[page + item]);    
            }
        }
    }
    
    // public static void GenerateMenu(MenuOptions options, string[] args, string del)
    // {
    //     var menuPages = (int)Math.Floor((double)options.Count() / 2);
    //     var lastPageItemQty = options.Count() % 9;
    //     //string? input;
    //
    //     if (menuPages > 1)
    //     {
    //         for (var page = 0; page < menuPages; page++)
    //         {
    //             for (var item = 1; item <= 10; item++)
    //             {
    //                 if (item == 10)
    //                 {
    //                     if (args.Contains("back"))
    //                     {
    //                         Console.WriteLine("b. Back");                    
    //                     }
    //                     
    //                     if (args.Contains("options"))
    //                     {
    //                         Console.WriteLine("0. Options");                    
    //                     }
    //                     
    //                     if (args.Contains("exit"))
    //                     {
    //                         Console.WriteLine("e. Exit");                    
    //                     }
    //                     
    //                     Console.WriteLine("Ввод:");
    //                     OperateMenu();
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine(item + ". " + options[page + item]);    
    //                 }
    //             }
    //
    //             //input = Console.ReadLine();
    //             OperateMenu(Console.ReadLine());
    //         }    
    //     }
    //     else
    //     {
    //         for (var item = 1; item <= lastPageItemQty + 1; item++)
    //         {
    //             if (item == lastPageItemQty + 1)
    //             {
    //                 if (args.Contains("back"))
    //                 {
    //                     Console.WriteLine("b. Back");                    
    //                 }
    //                     
    //                 if (args.Contains("options"))
    //                 {
    //                     Console.WriteLine("0. Options");                    
    //                 }
    //                     
    //                 if (args.Contains("exit"))
    //                 {
    //                     Console.WriteLine("e. Exit");                    
    //                 }
    //             }
    //             else
    //             {
    //                 Console.WriteLine(item + ". " + options[item]);    
    //             }
    //         }    
    //         
    //         Console.WriteLine("Ввод:");
    //     }
    //     
    //      
    // }

    public static void InvalidInput()
    {
        Console.Clear();
        Console.WriteLine("Было введено некорректное значение. Пожалуйста, попробуйте снова.");
    }
}