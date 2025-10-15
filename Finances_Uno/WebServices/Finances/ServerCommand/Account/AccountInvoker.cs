namespace Finances_Uno.WebServices.Finances.ServerCommand.Account;

public interface IAccountInvoker
{
    Task<APIResult> Get(BroadcastToken token, bool showInactive);
}

public class AccountInvoker : IAccountInvoker
{
    private IServiceWrapper _service;
    private IServerInvoker _invoker;
    private IAccountState _state;

    public AccountInvoker(IServiceWrapper service, IServerInvoker invoker, IAccountState state)
    {
        _service = service;
        _invoker = invoker;
        _state = state;
    }

    public Task<APIResult> Get(BroadcastToken token, bool showInactive)
    {
        var command = new AccountGet(_service, showInactive, _state);
        return _invoker.Perform(command, token);
    }
}
