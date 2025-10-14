namespace Finances_Uno.WebServices.Finances.Entities;

public interface IEntityState : IClear
{
    enumCacheChangeDomain CacheChangeDomain { get; }
}

public interface IEntityState<T> : IEntityState
{
    IEnumerable<T> Items { get; }
    bool IsLoaded { get; }
    Task Append(T item, enumCacheChangeDomain flags);
    Task Append(T item, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh);
    Task Append(IEnumerable<T> items, enumCacheChangeDomain flags);
    Task Append(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh);
    bool Contains(int hashCode);
    T Get(int hashCode);
    Task Merge(T item, enumCacheChangeDomain flags);
    Task Merge(T item, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh);
    Task Merge(IEnumerable<T> items, enumCacheChangeDomain flags);
    Task Merge(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh);
    Task Remove(IEnumerable<T> items, enumCacheChangeDomain flags);
    Task Remove(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh);
    void Reset();
    Task Set(T item);
    Task Set(IEnumerable<T> items);
    Func<Task>? OnChange { get; set; }
}

public abstract class EntityState<T> : IEntityState<T>, IDisposable where T : IEquatable<T>, ICopy<T>
{
    private ICacheChange _cacheChange;
    private IClearCollection _clear;
    private Dictionary<int, T> _items = new();
    private Dictionary<int, T> _oldValues = new();

    public IEnumerable<T> Items => Alter(_items.Values);
    public bool IsLoaded { get; private set; }
    public Func<Task>? OnChange { get; set; }
    public abstract enumCacheChangeDomain CacheChangeDomain { get; }

    public EntityState(ICacheChange cacheChange, IClearCollection clear)
    {
        cacheChange.Register(this);
        clear.Register(this);
        _cacheChange = cacheChange;
        _clear = clear;
    }

    public void Dispose()
    {
        _cacheChange.Deregister(this);
        _clear.Deregister(this);
    }

    public virtual IEnumerable<T> Alter(IEnumerable<T> items)
    {
        return items;
    }

    public Task Append(T item, enumCacheChangeDomain flags)
    {
        return Append(item, flags, CacheChangeDomain);
    }

    public async Task Append(T item, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        Reset();
        _items.Add(item.GetHashCode(), item);
        _oldValues.Add(item.GetHashCode(), item.Copy());
        if (OnChange != null)
            await OnChange();
        await ClearEverythingElse(flags, doNotRefresh);
    }

    public Task Append(IEnumerable<T> items, enumCacheChangeDomain flags)
    {
        return Append(items, flags, CacheChangeDomain);
    }

    public async Task Append(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        Reset();
        foreach (var item in items)
        {
            _items.Add(item.GetHashCode(), item);
            _oldValues.Add(item.GetHashCode(), item.Copy());
        }
        if (OnChange != null)
            await OnChange();
        await ClearEverythingElse(flags, doNotRefresh);
    }

    public async Task Clear()
    {
        _items.Clear();
        _oldValues.Clear();
        IsLoaded = false;
        if (OnChange != null)
            await OnChange();
    }

    public bool Contains(int hashCode)
    {
        return _items.ContainsKey(hashCode);
    }

    public T Get(int hashCode)
    {
        return _items[hashCode];
    }

    public Task Merge(T item, enumCacheChangeDomain flags)
    {
        return Merge(new List<T>() { item }, flags);
    }

    public Task Merge(T item, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        return Merge(new List<T>() { item }, flags, doNotRefresh);
    }

    public Task Merge(IEnumerable<T> items, enumCacheChangeDomain flags)
    {
        return Merge(items, flags, CacheChangeDomain);
    }

    public async Task Merge(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        foreach (var item in items)
        {
            var hash = item.GetHashCode();
            _items[hash] = item;
            _oldValues[hash] = item.Copy();
        }
        IsLoaded = true;
        if (OnChange != null)
            await OnChange();
        await ClearEverythingElse(flags, doNotRefresh);
    }

    public Task Remove(IEnumerable<T> items, enumCacheChangeDomain flags)
    {
        return Remove(items, flags, CacheChangeDomain);
    }

    public async Task Remove(IEnumerable<T> items, enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        Reset();
        foreach (var item in items)
        {
            var key = item.GetHashCode();
            if (_items.ContainsKey(key))
                _items.Remove(key);
            if (_oldValues.ContainsKey(key))
                _oldValues.Remove(key);
        }
        if (OnChange != null)
            await OnChange();
        await ClearEverythingElse(flags, doNotRefresh);
    }

    public void Reset()
    {
        foreach (var item in _items.Keys.ToList())
        {
            if (_oldValues.ContainsKey(item))
                _items[item] = _oldValues[item].Copy();
        }
    }

    public async Task Set(T item)
    {
        await Set(new List<T>() { item });
    }

    public async Task Set(IEnumerable<T> items)
    {
        _items = items.ToDictionary(x => x.GetHashCode(), x => x);
        _oldValues = items
            .Select(x => x.Copy())
            .ToDictionary(x => x.GetHashCode(), x => x);
        IsLoaded = true;
        if (OnChange != null)
            await OnChange();
    }

    private async Task ClearEverythingElse(enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        flags = SetDoNotRefresh(flags, doNotRefresh);
        await _cacheChange.Clear(flags);
    }

    private enumCacheChangeDomain SetDoNotRefresh(enumCacheChangeDomain flags, enumCacheChangeDomain doNotRefresh)
    {
        ulong flagsAsNum = (ulong)flags;
        ulong doNotRefreshAsNum = (ulong)doNotRefresh;
        doNotRefreshAsNum &= flagsAsNum; // Remove anything from flags that was not cached
        if (doNotRefreshAsNum != 0)
        {
            flagsAsNum ^= doNotRefreshAsNum; // Xor to remove anything in doNotRefresh
        }
        return (enumCacheChangeDomain)flagsAsNum;
    }
}
