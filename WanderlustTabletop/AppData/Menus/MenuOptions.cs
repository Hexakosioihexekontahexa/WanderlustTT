namespace WanderlustTabletop.AppData.Menus;

public class MenuOptions
{
    private readonly List<string> _optionList;
    
    public string this[int i] => _optionList[i];

    public MenuOptions(List<string> optionList)
    {
        _optionList = optionList;
    }

    public int Count()
    {
        return _optionList.Count;
    }

    public void Add(string s)
    {
        _optionList.Add(s);
    }
}