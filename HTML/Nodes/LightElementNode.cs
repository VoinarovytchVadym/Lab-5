using System.Diagnostics;
using HTML.LifeCycleHooks;
using HTML.States;

namespace HTML.Nodes;

public class LightElementNode(string tagName, string display, string closingType, List<string> classes, List<LightNode> childes)
    : LightNode
{
    public string TagName { get; set; } = tagName;
    private string Display { get; set; } = display;
    private string ClosingType { get; set; } = closingType;
    public List<string> Classes { get; private set;} = classes;
    public List<LightNode> Childes { get;} = childes;
    private IElementState CurrentState { get; set; } = new NormalState();
    private NodeLifeCycleHooks _hooks = new NodeLifeCycleHooks();
    
    public override string OuterHTML
    {
        get
        {
            string classes = string.Join(" ", Classes);
            string classesString = "";
            if (classes.Length > 0)
            {
                classesString = $" class=\"{classes}\"";
            }
            string child = string.Join("", Childes.ConvertAll(node => node.OuterHTML));

            return ClosingType == "selfClosing" ? $"<{TagName}{classesString}/>" : $"<{TagName}{classesString}>{child}</{TagName}>";
        }
    }

    public override string InnerHTML
    {
        get
        { return string.Join("", Childes.ConvertAll(node => node.OuterHTML)); }
    }
    
    
    private static readonly Dictionary<string, LightElementNode> FlyweightPool = new Dictionary<string, LightElementNode>();
    

    public static LightElementNode GetElementNode(string tagName, string display, string closingType, List<string> classes, List<LightNode> childes)
    {
        string key = $"{tagName}_{display}_{closingType}_{string.Join(",", classes)}";

        if (!FlyweightPool.TryGetValue(key, out LightElementNode? value))
        {
            value = new LightElementNode(tagName, display, closingType, classes, childes);
            FlyweightPool[key] = value;
        }

        return value;
    }

    public string GetAttributeValue(string attributeName)
    {
        switch(attributeName)
        {
            case "TagName":
                return TagName;
                break;
            case "Display":
                return Display;
                break;
            case "ClosingType":
                return ClosingType;
                break;
            case "Classes":
                return string.Join(", ", Classes);
                break;
            case "Childes":
                return string.Join(", ", Childes.ConvertAll(node => node.OuterHTML));
                break;
            default:
                return "";
        }
    }

    public void SetAttributeValue(string attributeName, string newValue)
    {
        switch(attributeName)
        {
            case "TagName":
                TagName = newValue;
                break;
            case "Display":
                Display = newValue;
                break;
            case "ClosingType":
                ClosingType = newValue;
                break;
            case "Classes":
                Classes = new List<string>(newValue.Split(new string[] { ", " }, StringSplitOptions.None));
                break;
        }
    }
    public void ChangeState(IElementState newState)
    {
        CurrentState = newState;
    }
    public void Click()
    {
        CurrentState.HandleClick(this);
    }

    public void Hover()
    {
        CurrentState.HandleHover(this);
    }

    public void RunLifeCycleHooks()
    {
        _hooks.Run(this);
    }
}