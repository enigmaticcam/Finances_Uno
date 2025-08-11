using Finances_Uno.Presentation.Account;

namespace Finances_Uno.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(INavigator navigator)
    {
        _navigator = navigator;
    }

    public async Task GoToAccounts()
    {
        await _navigator.NavigateViewModelAsync<AccountModel>(this);
    }
}
