namespace Finances_Uno.WebServices.Finances.Entities;

public interface IEntityUpdateState<T> : IClear
{
    IEnumerable<T> Items { get; }
    void Add(int id, T item);
}

public class EntityUpdateState<TUpdate, TEntity> : IEntityUpdateState<TUpdate>, IDisposable
{
    private IEntityState<TEntity> _state;
    private IClearCollection _clear;
    private Dictionary<int, TUpdate> _items = new();

    public EntityUpdateState(IEntityState<TEntity> state, IClearCollection clear)
    {
        clear.Register(this);
        _clear = clear;
        _state = state;
        _state.OnChange += Clear;
    }

    public IEnumerable<TUpdate> Items => _items.Values;

    public void Add(int id, TUpdate item)
    {
        _items[id] = item;
    }

    public Task Clear()
    {
        _items.Clear();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _clear.Deregister(this);
    }
}

