using Newtonsoft.Json;

namespace WanderlustTabletop.AppData.Places.Forests;

public class Forest
{
    public string name { get; set; }
    public List<ForestZone> zones { get; set; }
    public int id;
}

public class ForestZone
{
    public string name { get; set; }
}

public class ForestContainer
{
    public List<Forest> Forests { get; } = new();

    public static void InitializeForests()
    {
        const string forestJsonPath = "AppData/Places/Forests/Forests.json";
        var file = File.OpenText(forestJsonPath);
        var serializer = new JsonSerializer();
        var forestContainer = (ForestContainer)serializer.Deserialize(file, typeof(ForestContainer))!;
        //var deserialization = serializer.Deserialize(file, typeof(string));

        for (var i = 0; i < forestContainer.Forests.Count; i++)
        {
            forestContainer.Forests[i].id = i;
        }
    }

    public Forest GetForestByName(string forestName)
    {
        foreach (var forest in Forests.Where(forest => forestName == forest.name))
        {
            return forest;
        }

        throw new Exception("Cannot find forest named: " + forestName);
    }
}