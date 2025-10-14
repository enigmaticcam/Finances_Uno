namespace Finances_Uno.WebServices.Finances;

[Flags]
public enum enumCacheChangeDomain : ulong
{
    None = 0,
    Account = 1,
    Adjustment = 1 << 1,
    BalanceWindowAccount = 1 << 2,
    BalanceWindowBudget = 1 << 3,
    BalanceWindow = 1 << 4,
    Budget = 1 << 5,
    BudgetIncome = 1 << 6,
    BudgetProjection = 1 << 7,
    BudgetSystemType = 1 << 8,
    BudgetType = 1 << 9,
    Ledger = 1 << 10,
    LedgerLoad = 1 << 11,
    LedgerLoaderFromFile = 1 << 12,
    Phrase = 1 << 13,
    RecurringType = 1 << 14,
    LedgerLoadType = 1 << 15,
    Tag = 1 << 16
}

[Flags]
public enum enumLedgerLoadType
{
    None = 0,
    Ready = 1,
    Archived = 1 << 1,
    Duplicate = 1 << 2
}
