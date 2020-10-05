using System;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace AddMessageNotificationSample
{
    public class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register app-specific services
                    services.AddSingleton<AppState>();
                })
                .Build();

            MainPage = new ContentPage();
            _host.AddComponent<HelloWorld>(parent: MainPage);
        }

        // TODO: Register this method with the notification system
        void SendMessageToMainPage(string body)
        {
            // Add the new message to the AppState's message list
            var appState = _host.Services.GetService<AppState>();
            appState.AddMessage(body);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
