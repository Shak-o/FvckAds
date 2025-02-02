namespace FvckAds.SimpleWeb.Components.Models;

public class MessageModel
{
    public bool IsCurrent { get; set; }
    public string Tag { get; set; }
    public string Text { get; set; }
    public DateTime UtcDate { get; set; }
    
    public MessageModel(bool isCurrent, string tag, string text)
    {
        IsCurrent = isCurrent;
        Tag = tag;
        Text = text;
    }
}

public class MessageThread
{
    public Guid Id { get; set; }
    public required string ThreadName { get; set; }
    public required string ThreadAuthor { get; set; }
    public string? Description { get; set; }
    public List<MessageModel> Messages { get; set; } = [];
}