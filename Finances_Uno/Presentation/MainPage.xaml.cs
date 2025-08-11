using Finances_Uno.Presentation.Account;

namespace Finances_Uno;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void GoToAccounts(object sender, RoutedEventArgs e)
    {
        _ = this.Navigator()?.NavigateViewAsync<AccountMainPage>(this);
    }
}
