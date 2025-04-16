csharp
using Firebase.CloudMessaging;

public interface IFirebaseNotificationService
{
    void OnMessageReceived(FirebaseMessagingServiceReceiveMessageEventArgs e);
}