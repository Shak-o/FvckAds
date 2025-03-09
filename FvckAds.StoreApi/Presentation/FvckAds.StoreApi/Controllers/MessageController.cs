using FvckAds.StoreApi.Domain.Messages;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.StoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    [HttpPost]
    public Task StoreMessage(Message message, CancellationToken cancellationToken) => throw new NotImplementedException();
    
    [HttpGet]
    public Task<List<Message>> GetMessage(CancellationToken cancellationToken) => throw new NotImplementedException();
}