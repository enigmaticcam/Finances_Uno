using Finances_Uno.Models.ViewModels;

namespace Finances_Uno.Models.DataModels;

public class AccountViewModel : DispatchedBindableBase
{
    private readonly DTO_Account _account;

    public AccountViewModel(DTO_Account account)
    {
        _account = account;
    }

    public int AccountId => _account.AccountId;
    public string AccountName => _account.AccountName;
    public decimal AccountLimit => _account.AccountLimit;
    public bool IsActive => _account.IsActive;
    public bool NeedsAdjust => _account.NeedsAdjust;
}
