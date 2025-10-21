using System.Collections.ObjectModel;
using Finances_Uno.Commands.Account;
using Finances_Uno.Models.DataModels;
using Finances_Uno.WebServices.Finances;
using Finances_Uno.WebServices.Finances.ServerCommand.Account;

namespace Finances_Uno.Models.ViewModels;

public class AccountPageViewModel : DispatchedBindableBase, IAccountGetReceiver
{
    private IServiceWrapper _service;
    private IAccountState _accountState;
    private bool _showInactive;
    private ObservableCollection<AccountViewModel> _accounts = new();

    public AccountPageViewModel(IServiceWrapper service, IAccountState accountState)
    {
        _service = service;
        _accountState = accountState;
        AccountGet = new AccountGetCommand(_service, ShowInactive, _accountState);
    }

    public bool ShowInactive
    {
        get => _showInactive;
        set => SetProperty(ref _showInactive, value);
    }

    public IEnumerable<AccountViewModel> Accounts => _accounts;

    public ICommand AccountGet { get; }

    public void SetAccounts(IEnumerable<DTO_Account> accounts)
    {
        _accounts = new(accounts.Select(x => new AccountViewModel(x)));
    }
}
