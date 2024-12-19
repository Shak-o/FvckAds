namespace FvckAds.SimpleWeb.Components.Models;

public class MessageModel
{
    public bool IsCurrent { get; set; }
    public string Tag { get; set; }
    public string Text { get; set; }

    public MessageModel(bool isCurrent, string tag, string text)
    {
        IsCurrent = isCurrent;
        Tag = tag;
        Text = text;
    }
}