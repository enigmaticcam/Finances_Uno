using Finances_Uno.Models.DataModels;

namespace Finances_Uno.WebServices.Finances.ServerCommand.Account;

public class AccountGet : IServerCommand<APIResult>
{
    private IServiceWrapper _service;
    private bool _showInactive;
    private IAccountState _state;

    public AccountGet(IServiceWrapper service, bool showInactive, IAccountState state)
    {
        _service = service;
        _showInactive = showInactive;
        _state = state;
    }

    public async Task<APIResult> Execute()
    {
        var result = await _service.AccountsGet(_showInactive);
        if (result.IsSuccess && result.Obj != null)
        {
            var items = result.Obj
                .Select(x => new DTO_Account(x))
                .ToList();
            await _state.Set(items);
        }
        return result;
    }
}

