using Finances_Uno.Models.DataModels;
using Finances_Uno.WebServices.Finances.Entities;

namespace Finances_Uno.WebServices.Finances.ServerCommand.Account;

public interface IAccountState : IEntityState<DTO_Account>
{
    string AccountText(int accountId);
}

public class AccountState : EntityState<DTO_Account>, IAccountState
{
    public AccountState(ICacheChange cacheChange, IClearCollection clear) : base(cacheChange, clear)
    {
    }

    public override enumCacheChangeDomain CacheChangeDomain => enumCacheChangeDomain.Account;

    public string AccountText(int accountId)
    {
        if (Contains(accountId))
        {
            return Get(accountId).AccountName;
        }
        return "";
    }
}

