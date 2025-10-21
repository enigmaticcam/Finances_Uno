using Finances_Uno.Models.ViewModels;
using Finances_Uno.Presentation;
using Finances_Uno.Presentation.Account;
using Finances_Uno.WebServices.Finances.ServerCommand.Account;

namespace Finances_Uno;
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected override void OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)
    {
        if (args.Kind == Windows.ApplicationModel.Activation.ActivationKind.Protocol)
        {
            // TODO: Handle URI Activation
            // ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
            // The received URI is eventArgs.Uri.AbosoluateUri
            // var x = eventArgs.Uri.AbsoluteUri;

        }
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                // Enable localization (see appsettings.json for supported languages)
                .UseLocalization()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAccountState, AccountState>();
                })
                .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        //Host = await builder.NavigateAsync<MainPage>();

        Host = builder.Build();

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (MainWindow.Content is not Frame rootFrame)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            // Place the frame in the current Window
            MainWindow.Content = rootFrame;
        }

        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), args.Arguments);
        }
        // Ensure the current window is active
        MainWindow.Activate();
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            //new ViewMap(ViewModel: typeof(ShellModel)),
            new ViewMap<MainPage, MainModel>(),
            new ViewMap<AccountMainPage, AccountPageViewModel>()
        );
    }
}
