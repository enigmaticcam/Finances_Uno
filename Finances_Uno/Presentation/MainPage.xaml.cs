using Finances_Uno.Presentation;

namespace Finances_Uno;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void GoToAccounts(object sender, RoutedEventArgs e)
    {
        //Frame.Navigate(typeof(AccountMainPage));
        //Frame.Navigate(typeof(MainLogin));
    }

    private void GotoCatAPI(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(CatAPIPage));
    }
}
