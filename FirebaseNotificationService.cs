csharp
using Firebase.CloudMessaging;
using Microsoft.Extensions.Logging;

namespace BlazorNotify;

public interface IFirebaseNotificationService
{
    void OnMessageReceived(FirebaseMessagingServiceReceiveMessageEventArgs args);
}

public class FirebaseNotificationService : IFirebaseNotificationService
{
    private readonly ILogger<FirebaseNotificationService> _logger;

    public FirebaseNotificationService(ILogger<FirebaseNotificationService> logger)
    {
        _logger = logger;
    }

    public void OnMessageReceived(FirebaseMessagingServiceReceiveMessageEventArgs args)
    {
        var message = args.Message;
        if (message != null && message.Data != null)
        {
            _logger.LogInformation("Received message:");
            foreach (var key in message.Data.Keys)
            {
                _logger.LogInformation($"  {key}: {message.Data[key]}");
            }
        }
    }
}