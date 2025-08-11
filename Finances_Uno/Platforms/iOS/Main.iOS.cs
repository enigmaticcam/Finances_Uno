using UIKit;
using Uno.UI.Hosting;

namespace Finances_Uno.iOS;
public class EntryPoint
{
    // This is the main entry point of the application.
    public static void Main(string[] args)
    {
        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseAppleUIKit()
            .Build();

        host.Run();
    }
}
