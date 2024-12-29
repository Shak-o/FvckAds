namespace FvckAds.StreamManagerApi.Interfaces;

public interface IChatClient
{
    Task ReceiveMessage(string tag, string text, int threadId);
}