namespace Finances_Uno.WebServices.Finances.ServerCommand;

public interface IServerInvoker
{
    Task<APIResult> Perform(IServerCommand<APIResult> command, BroadcastToken token);
    Task<APIResult<T>> Perform<T>(IServerCommand<APIResult<T>> command, BroadcastToken token);
}

public class ServerInvoker : IServerInvoker
{
    private IServerStatus _server;

    public ServerInvoker(IServerStatus server)
    {
        _server = server;
    }

    public async Task<APIResult> Perform(IServerCommand<APIResult> command, BroadcastToken token)
    {
        await _server.StartTask(token);
        APIResult result = APIResult.Fail("");
        try
        {
            result = await command.Execute();
        }
        catch (Exception ex)
        {
            result = APIResult.Fail(ex.Message);
        }
        finally
        {
            await _server.EndTask(token, result);
        }
        return result;
    }

    public async Task<APIResult<T>> Perform<T>(IServerCommand<APIResult<T>> command, BroadcastToken token)
    {
        await _server.StartTask(token);
        APIResult<T> result = APIResult<T>.Fail("");
        try
        {
            result = await command.Execute();
        }
        catch (Exception ex)
        {
            result = APIResult<T>.Fail(ex.Message);
        }
        finally
        {
            await _server.EndTask(token, result);
        }
        return result;
    }
}

