namespace FvckAds.StreamManagerApi.Interfaces;

public interface IChatClient
{
    Task ReceiveMessage(int userId, string message);
}