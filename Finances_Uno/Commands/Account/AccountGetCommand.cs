using Finances_Uno.Models.DataModels;
using Finances_Uno.WebServices.Finances;
using Finances_Uno.WebServices.Finances.ServerCommand.Account;

namespace Finances_Uno.Commands.Account;

public interface IAccountGetReceiver
{
    void SetAccounts(IEnumerable<DTO_Account> accounts);
}

public class AccountGetCommand : AsyncCommandBase
{
    private IServiceWrapper _service;
    private bool _showInactive;
    private IAccountState _state;
    private IAccountGetReceiver? _receiver;

    public AccountGetCommand(IServiceWrapper service, bool showInactive, IAccountState state, IAccountGetReceiver? receiver = null)
    {
        _service = service;
        _showInactive = showInactive;
        _state = state;
        _receiver = receiver;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var result = await _service.AccountsGet(_showInactive);
        if (result.IsSuccess && result.Obj != null)
        {
            var items = result.Obj
                .Select(x => new DTO_Account(x))
                .ToList();
            await _state.Set(items);
            if (_receiver != null)
            {
                _receiver.SetAccounts(_state.Items);
            }
        }
    }
}
