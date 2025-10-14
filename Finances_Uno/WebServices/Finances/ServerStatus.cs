namespace Finances_Uno.WebServices.Finances;

public interface IServerStatus
{
    bool IsRunning { get; }
    Task StartTask(BroadcastToken token);
    Task EndTask(BroadcastToken token, APIResult result);
}

public class ServerStatus : IServerStatus
{
    private static object _lock = new object();
    private int _taskCount;
    private List<APIResult> _results = new List<APIResult>();

    public bool IsRunning { get; private set; }

    public async Task StartTask(BroadcastToken token)
    {
        bool canBroadCast = false;
        lock (_lock)
        {
            if (_taskCount == 0)
            {
                _results.Clear();
                canBroadCast = true;
            }
            _taskCount++;
            IsRunning = true;
        }
        if (canBroadCast)
        {
            if (token.OnRunning != null)
                await token.OnRunning(true);
        }
    }

    public async Task EndTask(BroadcastToken token, APIResult result)
    {
        bool canBraodCast = false;
        lock (_lock)
        {
            _taskCount--;
            _results.Add(result);
            if (_taskCount == 0)
                canBraodCast = true;
        }
        if (canBraodCast)
        {
            if (token.OnRunning != null)
                await token.OnRunning(false);
            if (token.OnComplete != null)
                await token.OnComplete(_results);
            IsRunning = false;
        }
    }
}

public class BroadcastToken
{
    public Func<bool, Task>? OnRunning { get; set; }
    public Func<List<APIResult>, Task>? OnComplete { get; set; }
}
