﻿using Newtonsoft.Json;
using WanderlustTabletop.AppData.Locations.Plains.PlainZones;

namespace WanderlustTabletop.AppData.Locations.Plains;

public class PlainData
{
    public static List<Plain> PlainList { get; private set; }

    public static void InitializePlainLocations()
    {
        var json = File.ReadAllText(JsonData.TerrinothPlainJsonPath);
        var plainDataJson = JsonConvert.DeserializeObject<PlainList>(json);
        PlainList = plainDataJson.Plains;
        PlainZoneData.InitializePlainZones();
    }

    public static void InitializePlainLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var plainDataJson = JsonConvert.DeserializeObject<PlainList>(json);
        PlainList = plainDataJson.Plains;
        PlainZoneData.InitializePlainZones();
    }

    public static Plain GetPlainByName(string plainName)
    {
        foreach (var plain in PlainList.Where(plain => plainName == plain.Name))
        {
            return plain;
        }

        throw new Exception("Cannot find plain named: " + plainName);
    }

    public static Location GetRandomPlainLocationByWeight()
    {
        var plainName = new List<string>();
        var plainWeight = new List<int>();

        foreach (var plain in PlainList)
        {
            plainName.Add(plain.Name);
            plainWeight.Add(plain.Weight);
        }

        var random = new Random();
        var randomPlainNumber = random.Next(1, plainWeight.Sum() + 1);

        // Определение выпавшего объекта
        var cumulativeChance = 0;
        string selectedPlainName = null;

        for (var i = 0; i < plainWeight.Count; i++)
        {
            cumulativeChance += plainWeight[i];
            if (randomPlainNumber <= cumulativeChance)
            {
                selectedPlainName = plainName[i];
                break;
            }
        }

        var targetPlain = GetPlainByName(selectedPlainName);

        if (targetPlain.Zones != null)
        {
            return targetPlain.Name is "Uncategorized" or "Столицы" ? 
                PlainZoneData.GetPlainZoneByWeightAndTargetPlain(targetPlain) : 
                PlainZoneData.GetPlainZoneChanceByWeightAndTargetPlain(targetPlain);
        }
#if DEBUG
        Console.WriteLine(targetPlain.Name);
#endif
        return targetPlain;
    }
}