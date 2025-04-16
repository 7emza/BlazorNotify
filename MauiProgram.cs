using Firebase.CloudMessaging;
using Firebase;
using Microsoft.Extensions.Logging;
using Plugin.Firebase.CloudMessaging;

namespace BlazorNotify
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            FirebaseApp.InitializeApp(Platform.CurrentActivity.ApplicationContext);

            CrossFirebaseCloudMessaging.Current.NotificationPresentationOptions = NotificationPresentationOptions.Sound | NotificationPresentationOptions.Alert;

            // Add message delegate to handle the message
            CrossFirebaseCloudMessaging.Current.OnMessageReceived += (sender, args) => { MauiProgram.Current.Services.GetRequiredService<IFirebaseNotificationService>().OnMessageReceived(args); };
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton<IFirebaseNotificationService, FirebaseNotificationService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
            
        }

        public static MauiApp Current { get; private set; }
        static MauiProgram() {
            Current = CreateMauiApp();
        }
    }
}
