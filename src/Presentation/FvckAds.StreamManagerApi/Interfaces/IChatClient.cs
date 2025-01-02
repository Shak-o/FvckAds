namespace FvckAds.StreamManagerApi.Interfaces;

public interface IChatClient
{
    Task ReceiveMessage(string tag, string text, Guid threadId);
    Task AddNewThread(Guid threadId, string threadName, string threadAuthor, string description);
}