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

namespace WanderlustTabletop.AppData;

public static class Statistics
{
    public static void Run()
    {
        //PlayerQtyMenu.DisplayPlayerQtyStartMenu();
        //ForestData.GetForestByName("Древо горя");
        // for (int i = 0; i < 50; i++)
        // {
        //     ForestData.GetRandomForestLocationByWeight();    
        // }

        //WorldData.GetLocationByName()
        Console.WriteLine("---------------");
        var dataList = new List<string>();
        for (int i = 0; i < 10000; i++)
        {
            var loc = Location.GetRandomLocationByWeight();
            dataList.Add(loc.Name);
            //Console.WriteLine("Random location: " + loc.Name);
        }
        Console.WriteLine("---------------");
        
        
        Console.WriteLine($"Forest objs: {ForestData.ForestList.Count}");
        Console.WriteLine($"Hill objs: {HillData.HillList.Count}");
        Console.WriteLine($"Lake objs: {LakeData.LakeList.Count}");
        Console.WriteLine($"Mountain objs: {MountainData.MountainList.Count}");
        Console.WriteLine($"Plain objs: {PlainData.PlainList.Count}");
        Console.WriteLine($"Swamp objs: {SwampData.SwampList.Count}");
        Console.WriteLine($"Castle objs: {CastleData.CastleList.Count}");
        Console.WriteLine($"Sanct objs: {SanctuaryData.SanctuaryList.Count}");
        Console.WriteLine($"Town objs: {TownData.TownList.Count}");
        Console.WriteLine($"Village objs: {VillageData.VillageList.Count}");

        Console.WriteLine("---------------");
// Получаем словарь с уникальными значениями и количеством их вхождений
        // var frequencyDictionary = dataList
        //     .GroupBy(item => item.ToLower())
        //     .OrderByDescending(group => group.Count()) // Сортируем по количеству вхождений
        //     .ToDictionary(group => group.Key, group => group.Count());
        var frequencyDictionary = dataList
            .GroupBy(item => item)
            .OrderBy(group => group.Key) // Сортируем по ключу (алфавитный порядок)
            .ToDictionary(group => group.Key, group => group.Count());

// Выводим результаты
        foreach (var item in frequencyDictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}