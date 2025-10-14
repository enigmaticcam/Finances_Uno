namespace Finances_Uno.WebServices.Finances.ServerCommand;

public interface IServerCommand
{
    Task Execute();
}

public interface IServerCommand<T>
{
    Task<T> Execute();
}

