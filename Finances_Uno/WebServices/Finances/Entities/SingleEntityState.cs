namespace Finances_Uno.WebServices.Finances.Entities;

public interface ISingleEntityState<T> : IClear
{
    T? Item { get; }
    bool IsLoaded { get; }
    void Set(T item);
}

public abstract class SingleEntityState<T> : ISingleEntityState<T>
{
    public T? Item { get; private set; }

    public bool IsLoaded { get; private set; }

    public Task Clear()
    {
        Item = default(T);
        IsLoaded = false;
        return Task.CompletedTask;
    }

    public void Set(T item)
    {
        Item = item;
        IsLoaded = true;
    }
}

