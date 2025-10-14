namespace Finances_Uno.WebServices.Finances.Entities;

public interface ICacheChange
{
    Task Clear(enumCacheChangeDomain flags);
    void Register(IEntityState entityState);
    void Deregister(IEntityState entityState);
}

public class CacheChange : ICacheChange
{
    private Dictionary<ulong, IEntityState> _states = new();

    public async Task Clear(enumCacheChangeDomain flags)
    {
        foreach (var state in _states)
        {
            if (((ulong)flags & state.Key) != 0)
            {
                await state.Value.Clear();
            }
        }
    }

    public void Deregister(IEntityState entityState)
    {
        if (_states.ContainsKey((ulong)entityState.CacheChangeDomain))
        {
            _states.Remove((ulong)entityState.CacheChangeDomain);
        }
    }

    public void Register(IEntityState entityState)
    {
        if (!_states.ContainsKey((ulong)entityState.CacheChangeDomain))
        {
            _states.Add((ulong)entityState.CacheChangeDomain, entityState);
        }
    }
}

