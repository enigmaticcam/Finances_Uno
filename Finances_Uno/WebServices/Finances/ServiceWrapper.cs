namespace Finances_Uno.WebServices.Finances;

public interface IServiceWrapper
{
    Task<APIResult<ICollection<AccountEntity>>> AccountsGet(bool showInactive);
    Task<APIResult<AccountEntity>> AccountsPost(AccountCreateDTO body);
    Task<APIResult<AccountEntity>> AccountsPut(AccountUpdateDTO body);
    Task<APIResult<AccountEntity>> AccountsIsactive(AccountUpdateIsActiveDTO body);
    Task<APIResult<AdjustmentEntity>> AdjustmentCreate(AdjustmentCreateDTO create);
    Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentCreate(List<AdjustmentCreateDTO> creates);
    Task<APIResult> AdjustmentDelete(List<int> ids);
    Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentGet();
    Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentGet(int balanceWindowId);
    Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentUpdate(List<AdjustmentUpdateDTO> updates);
    Task<APIResult<AccountEntity>> BalanceWindowAdjust(BalanceWindowAdjustDTO adjust);
    Task<APIResult> BalanceWindowClose(DateOnly endDate);
    Task<APIResult<BalanceWindowCloseCompare>> BalanceWindowCloseRequest(DateOnly endDate);
    Task<APIResult<ICollection<BalanceWindowAccountEntity>>> BalanceWindowCurrentaccountbalances();
    Task<APIResult<ICollection<BalanceWindowBudgetEntity>>> BalanceWindowCurrentbudegetbalances();
    Task<APIResult<BalanceWindowEntity>> BalanceWindowEmptyToSurplus();
    Task<APIResult<BalanceWindowEntity>> BalanceWindowEmptyToSurplus(List<AdjustmentCreateDTO> adjustments);
    Task<APIResult<ICollection<BalanceWindowAccountAdjustmentDTO>>> BalanceWindowGetAccountAdjustment();
    Task<APIResult<ICollection<BalanceWindowAuditDTO>>> BalanceWindowGetAudit(DateOnly startDate, DateOnly endDate);
    Task<APIResult<ICollection<BalanceWindowBudgetEntity>>> BalanceWindowGetBudgetBalance(int balanceWindowId);
    Task<APIResult<BalanceWindowCurrentDTO>> BalanceWindowGetCurrent();
    Task<APIResult<ICollection<AdjustmentCreateDTO>>> BalanceWindowGetEmptyToSurplus();
    Task<APIResult<ICollection<BalanceWindowEntity>>> BalanceWindowGetMore(int startBalanceWindowId);
    Task<APIResult> BalanceWindowRecalc(int balanceWindowId);
    Task<APIResult<BalanceWindowEntity>> BalanceWindowRefillBudgets();
    Task<APIResult<BalanceWindowEntity>> BalanceWindowRefillBudgets(List<int> idsToFill);
    Task<APIResult<BudgetEntity>> BudgetCreateAccrue(BudgetCreateSimpleDTO create);
    Task<APIResult<BudgetProjectionCreatedDTO>> BudgetCreateProjection(BudgetProjectionCreateFromNewBudgetDTO create);
    Task<APIResult<BudgetListDetailsDTO>> BudgetGet(bool showInactive);
    Task<APIResult> BudgetRefill(List<int> idsToFill);
    Task<APIResult<BudgetIncomeDetailsDTO>> BudgetIncomeGet();
    Task<APIResult<BudgetIncomeDetailsDTO>> BudgetIncomeSet(BudgetIncomeSetDTO set);
    Task<APIResult<ICollection<AdjustmentCreateDTO>>> BudgetProjectionCreateAdjustments(List<AdjustmentCreateDTO> creates);
    Task<APIResult<ICollection<BudgetProjectionEntity>>> BudgetProjectionGet(bool showInactive);
    Task<APIResult<ICollection<BudgetProjectionUpdateDTO>>> BudgetProjectionGetUpdates();
    Task<APIResult<ICollection<AdjustmentCreateDTO>>> BudgetProjectionGetAdjustments();
    Task<APIResult<BudgetProjectionEntity>> BudgetProjectionUpdate(BudgetProjectionUpdateDTO update);
    Task<APIResult<ICollection<BudgetProjectionEntity>>> BudgetProjectionUpdate(List<BudgetProjectionUpdateDTO> updates);
    Task<APIResult<ICollection<BudgetSystemTypeEntity>>> BudgetSystemTypeGet();
    Task<APIResult<ICollection<BudgetTypeEntity>>> BudgetTypeGet();
    Task<APIResult<BudgetEntity>> BudgetUpdate(BudgetUpdateDTO update);
    Task<APIResult<LedgerEntity>> LedgerAddTags(int ledgerId, List<int> existingTags, List<string> newTags);
    Task<APIResult<string>> EnvironmentGet();
    Task<APIResult<ICollection<LedgerEntity>>> LedgerGet();
    Task<APIResult<ICollection<LedgerEntity>>> LedgerGet(int balanceWindowId);
    Task<APIResult<ICollection<LedgerEntity>>> LedgerGet(LedgerFilterDTO filter);
    Task<APIResult<ICollection<LedgerEntity>>> LedgerUpdate(List<LedgerUpdateDTO> updates);
    Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadGet(enumLedgerLoadType flags);
    Task<APIResult<LedgerLoadEntity>> LedgerLoadAddTags(int ledgerLoadId, List<int> existingTags, List<string> newTags);
    Task<APIResult> LedgerLoadDelete(IEnumerable<int> ids);
    Task<APIResult> LedgerLoadLoadToLedger();
    Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadPut(List<LedgerLoadUpdateDTO> updates);
    Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadUpdateType(List<LedgerLoadTypeUpdateDTO> updates);
    Task<APIResult<ICollection<LedgerLoadTypeEntity>>> LedgerLoadTypeGet();
    Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadRefresh(enumLedgerLoadType flags);
    Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadSetBudgetsAuto(enumLedgerLoadType flags);
    Task<APIResult<LedgerLoaderFromFileEntity>> LedgerLoaderFromFilePost(LedgerLoaderFromFileCreateDTO create);
    Task<APIResult> LedgerLoaderFromFileDelete(int ledgerLoaderFromFileId);
    Task<APIResult<ICollection<LedgerLoaderFromFileEntity>>> LedgerLoaderFromFileGet();
    Task<APIResult<LedgerLoaderFromFileEntity>> LedgerLoaderFromFilePut(LedgerLoaderFromFileUpdateDTO update);
    Task<APIResult> LedgerLoaderFromFileUpload(int ledgerLoaderFromFileId, FileParameter file);
    Task<APIResult<ICollection<LedgerLoaderTypeEntity>>> LedgerLoaderType();
    Task<APIResult> OptionsRefreshCache();
    Task<APIResult<PhraseEntity>> PhraseAddTags(int phraseId, List<int> existingTags, List<string> newTags);
    Task<APIResult> PhraseDelete(IEnumerable<int> deletes);
    Task<APIResult<ICollection<ICollection<int>>>> PhraseFindOverlaps();
    Task<APIResult<ICollection<PhraseEntity>>> PhraseGet();
    Task<APIResult<PhraseEntity>> PhraseGet(int phraseId);
    Task<APIResult<PhraseEntity>> PhrasePost(int ledgerLoadId, PhraseCreateDTO body);
    Task<APIResult<PhraseEntity>> PhrasePut(PhraseUpdateDTO body);
    Task<APIResult<ICollection<RecurringTypeEntity>>> RecurringTypeGet();
    Task<APIResult<TagEntity>> TagCreate(string tagName);
    Task<APIResult> TagDelete(IEnumerable<int> ids);
    Task<APIResult<ICollection<TagEntity>>> TagGet();
    Task<APIResult<ICollection<TagEntity>>> TagUpdate(IEnumerable<TagUpdateDTO> updates);
}

public class ServiceWrapper : IServiceWrapper
{
    private IClient _client;

    public ServiceWrapper(IClient client)
    {
        _client = client;
    }

    private enumCacheChangeDomain GetCacheChangeDomain(string? text)
    {
        ulong value = 0;
        ulong.TryParse(text, out value);
        return (enumCacheChangeDomain)value;
    }

    public async Task<APIResult<ICollection<AccountEntity>>> AccountsGet(bool showInactive)
    {
        var result = await _client.ApiAccountsGetAsync(showInactive);
        return new APIResult<ICollection<AccountEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<AccountEntity>> AccountsPost(AccountCreateDTO body)
    {
        var result = await _client.ApiAccountsPostAsync(body);
        return new APIResult<AccountEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<AccountEntity>> AccountsPut(AccountUpdateDTO body)
    {
        var result = await _client.ApiAccountsPutAsync(body);
        return new APIResult<AccountEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<AccountEntity>> AccountsIsactive(AccountUpdateIsActiveDTO body)
    {
        var result = await _client.ApiAccountsIsactiveAsync(body);
        return new APIResult<AccountEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowAccountEntity>>> BalanceWindowCurrentaccountbalances()
    {
        var result = await _client.ApiBalanceWindowCurrentaccountbalancesAsync();
        return new APIResult<ICollection<BalanceWindowAccountEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadGet(enumLedgerLoadType flags)
    {
        var result = await _client.ApiLedgerLoadGetAsync((EnumLedgerLoadType)flags);
        return new APIResult<ICollection<LedgerLoadEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoaderTypeEntity>>> LedgerLoaderType()
    {
        var result = await _client.ApiLedgerLoaderTypeAsync();
        return new APIResult<ICollection<LedgerLoaderTypeEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<LedgerLoaderFromFileEntity>> LedgerLoaderFromFilePost(LedgerLoaderFromFileCreateDTO create)
    {
        var result = await _client.ApiLedgerLoaderFromFilePostAsync(create);
        return new APIResult<LedgerLoaderFromFileEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> LedgerLoaderFromFileDelete(int ledgerLoaderFromFileId)
    {
        var result = await _client.ApiLedgerLoaderFromFileDeleteAsync(ledgerLoaderFromFileId);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoaderFromFileEntity>>> LedgerLoaderFromFileGet()
    {
        var result = await _client.ApiLedgerLoaderFromFileGetAsync();
        return new APIResult<ICollection<LedgerLoaderFromFileEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<LedgerLoaderFromFileEntity>> LedgerLoaderFromFilePut(LedgerLoaderFromFileUpdateDTO update)
    {
        var result = await _client.ApiLedgerLoaderFromFilePutAsync(update);
        return new APIResult<LedgerLoaderFromFileEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> LedgerLoaderFromFileUpload(int ledgerLoaderFromFileId, FileParameter file)
    {
        var result = await _client.ApiLedgerLoaderFromFileUploadAsync(ledgerLoaderFromFileId, file);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowBudgetEntity>>> BalanceWindowCurrentbudegetbalances()
    {
        var result = await _client.ApiBalanceWindowCurrentbudgetbalancesAsync();
        return new APIResult<ICollection<BalanceWindowBudgetEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetListDetailsDTO>> BudgetGet(bool showInactive)
    {
        var result = await _client.ApiBudgetGetAsync(showInactive);
        return new APIResult<BudgetListDetailsDTO>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<PhraseEntity>> PhraseGet(int phraseId)
    {
        var result = await _client.ApiPhraseGetAsync(phraseId);
        return new APIResult<PhraseEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<PhraseEntity>> PhrasePost(int ledgerLoadId, PhraseCreateDTO body)
    {
        var result = await _client.ApiPhrasePostAsync(ledgerLoadId, body);
        return new APIResult<PhraseEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<PhraseEntity>> PhrasePut(PhraseUpdateDTO body)
    {
        var result = await _client.ApiPhrasePutAsync(body);
        return new APIResult<PhraseEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<PhraseEntity>>> PhraseGet()
    {
        var result = await _client.ApiPhraseAllAsync();
        return new APIResult<ICollection<PhraseEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadPut(List<LedgerLoadUpdateDTO> updates)
    {
        var result = await _client.ApiLedgerLoadPutAsync(updates);
        return new APIResult<ICollection<LedgerLoadEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> LedgerLoadDelete(IEnumerable<int> ids)
    {
        var result = await _client.ApiLedgerLoadDeleteAsync(ids);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> LedgerLoadLoadToLedger()
    {
        var result = await _client.ApiLedgerLoadLoadtoledgerGetAsync();
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> OptionsRefreshCache()
    {
        var result = await _client.ApiOptionsRefreshcacheAsync();
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadRefresh(enumLedgerLoadType flags)
    {
        var result = await _client.ApiLedgerLoadRefreshAsync((EnumLedgerLoadType)flags);
        return new APIResult<ICollection<LedgerLoadEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerEntity>>> LedgerGet()
    {
        var result = await _client.ApiLedgerGetAsync();
        return new APIResult<ICollection<LedgerEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerEntity>>> LedgerUpdate(List<LedgerUpdateDTO> updates)
    {
        var result = await _client.ApiLedgerPutAsync(updates);
        return new APIResult<ICollection<LedgerEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BudgetSystemTypeEntity>>> BudgetSystemTypeGet()
    {
        var result = await _client.ApiBudgetSystemTypeAsync();
        return new APIResult<ICollection<BudgetSystemTypeEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BudgetTypeEntity>>> BudgetTypeGet()
    {
        var result = await _client.ApiBudgetTypeAsync();
        return new APIResult<ICollection<BudgetTypeEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<RecurringTypeEntity>>> RecurringTypeGet()
    {
        var result = await _client.ApiRecurringTypeAsync();
        return new APIResult<ICollection<RecurringTypeEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetEntity>> BudgetCreateAccrue(BudgetCreateSimpleDTO create)
    {
        var result = await _client.ApiBudgetAccrueAsync(create);
        return new APIResult<BudgetEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetIncomeDetailsDTO>> BudgetIncomeGet()
    {
        var result = await _client.ApiBudgetIncomeGetAsync();
        return new APIResult<BudgetIncomeDetailsDTO>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetIncomeDetailsDTO>> BudgetIncomeSet(BudgetIncomeSetDTO set)
    {
        var result = await _client.ApiBudgetIncomePutAsync(set);
        return new APIResult<BudgetIncomeDetailsDTO>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowEntity>>> BalanceWindowGetMore(int startBalanceWindowId)
    {
        var result = await _client.ApiBalanceWindowGetmoreAsync(startBalanceWindowId);
        return new APIResult<ICollection<BalanceWindowEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowCurrentDTO>> BalanceWindowGetCurrent()
    {
        var result = await _client.ApiBalanceWindowCurrentAsync();
        return new APIResult<BalanceWindowCurrentDTO>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowCloseCompare>> BalanceWindowCloseRequest(DateOnly endDate)
    {
        var result = await _client.ApiBalanceWindowGetcloseAsync(endDate);
        return new APIResult<BalanceWindowCloseCompare>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> BalanceWindowClose(DateOnly endDate)
    {
        var result = await _client.ApiBalanceWindowCloseAsync(endDate);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetProjectionCreatedDTO>> BudgetCreateProjection(BudgetProjectionCreateFromNewBudgetDTO create)
    {
        var result = await _client.ApiBudgetProjectionPostAsync(create);
        return new APIResult<BudgetProjectionCreatedDTO>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetProjectionEntity>> BudgetProjectionUpdate(BudgetProjectionUpdateDTO update)
    {
        var result = await _client.ApiBudgetProjectionPutAsync(update);
        return new APIResult<BudgetProjectionEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BudgetEntity>> BudgetUpdate(BudgetUpdateDTO update)
    {
        var result = await _client.ApiBudgetPutAsync(update);
        return new APIResult<BudgetEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<AccountEntity>> BalanceWindowAdjust(BalanceWindowAdjustDTO adjust)
    {
        var result = await _client.ApiBalanceWindowAdjustAsync(adjust);
        return new APIResult<AccountEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentGet()
    {
        var result = await _client.ApiAdjustmentGetAsync();
        return new APIResult<ICollection<AdjustmentEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<AdjustmentEntity>> AdjustmentCreate(AdjustmentCreateDTO create)
    {
        var result = await _client.ApiAdjustmentPostAsync(create);
        return new APIResult<AdjustmentEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> AdjustmentDelete(List<int> ids)
    {
        var result = await _client.ApiAdjustmentDeleteAsync(ids);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentUpdate(List<AdjustmentUpdateDTO> updates)
    {
        var result = await _client.ApiAdjustmentPutAsync(updates);
        return new APIResult<ICollection<AdjustmentEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BudgetProjectionEntity>>> BudgetProjectionGet(bool showInactive)
    {
        var result = await _client.ApiBudgetProjectionGetAsync(showInactive);
        return new APIResult<ICollection<BudgetProjectionEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentCreateDTO>>> BudgetProjectionGetAdjustments()
    {
        var result = await _client.ApiBudgetProjectionAdjustmentsGetAsync();
        return new APIResult<ICollection<AdjustmentCreateDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentCreateDTO>>> BudgetProjectionCreateAdjustments(List<AdjustmentCreateDTO> creates)
    {
        var result = await _client.ApiBudgetProjectionAdjustmentsPostAsync(creates);
        return new APIResult<ICollection<AdjustmentCreateDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowAuditDTO>>> BalanceWindowGetAudit(DateOnly startDate, DateOnly endDate)
    {
        var result = await _client.ApiBalanceWindowGetauditAsync(startDate, endDate);
        return new APIResult<ICollection<BalanceWindowAuditDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> BalanceWindowRecalc(int balanceWindowId)
    {
        var result = await _client.ApiBalanceWindowRecalcAsync(balanceWindowId);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> BudgetRefill(List<int> idsToFill)
    {
        var result = await _client.ApiBudgetRefillAsync(idsToFill);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BudgetProjectionUpdateDTO>>> BudgetProjectionGetUpdates()
    {
        var result = await _client.ApiBudgetProjectionUpdatesGetAsync();
        return new APIResult<ICollection<BudgetProjectionUpdateDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BudgetProjectionEntity>>> BudgetProjectionUpdate(List<BudgetProjectionUpdateDTO> updates)
    {
        var result = await _client.ApiBudgetProjectionUpdatesPutAsync(updates);
        return new APIResult<ICollection<BudgetProjectionEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerEntity>>> LedgerGet(int balanceWindowId)
    {
        var result = await _client.ApiLedgerInBalanceWinodwAsync(balanceWindowId);
        return new APIResult<ICollection<LedgerEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentGet(int balanceWindowId)
    {
        var result = await _client.ApiAdjustmentInBalanceWinodwAsync(balanceWindowId);
        return new APIResult<ICollection<AdjustmentEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowAccountAdjustmentDTO>>> BalanceWindowGetAccountAdjustment()
    {
        var result = await _client.ApiBalanceWindowAccountadjustmentAsync();
        return new APIResult<ICollection<BalanceWindowAccountAdjustmentDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentCreateDTO>>> BalanceWindowGetEmptyToSurplus()
    {
        var result = await _client.ApiBalanceWindowEmptytosurplusGetAsync();
        return new APIResult<ICollection<AdjustmentCreateDTO>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<AdjustmentEntity>>> AdjustmentCreate(List<AdjustmentCreateDTO> creates)
    {
        var result = await _client.ApiAdjustmentCreatemanyAsync(creates);
        return new APIResult<ICollection<AdjustmentEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<BalanceWindowBudgetEntity>>> BalanceWindowGetBudgetBalance(int balanceWindowId)
    {
        var result = await _client.ApiBalanceWindowBudgetbalanceAsync(balanceWindowId);
        return new APIResult<ICollection<BalanceWindowBudgetEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowEntity>> BalanceWindowEmptyToSurplus(List<AdjustmentCreateDTO> adjustments)
    {
        var result = await _client.ApiBalanceWindowEmptytosurplusPutAsync(adjustments);
        return new APIResult<BalanceWindowEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowEntity>> BalanceWindowRefillBudgets(List<int> idsToFill)
    {
        var result = await _client.ApiBalanceWindowRefillbudgetsAsync(idsToFill);
        return new APIResult<BalanceWindowEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowEntity>> BalanceWindowEmptyToSurplus()
    {
        var result = await _client.ApiBalanceWindowEmptytosurplussimpleAsync();
        return new APIResult<BalanceWindowEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<BalanceWindowEntity>> BalanceWindowRefillBudgets()
    {
        var result = await _client.ApiBalanceWindowRefillbudgetssimpleAsync();
        return new APIResult<BalanceWindowEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadSetBudgetsAuto(enumLedgerLoadType flags)
    {
        var result = await _client.ApiLedgerLoadSetbudgetsautoAsync((EnumLedgerLoadType)flags);
        return new APIResult<ICollection<LedgerLoadEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerEntity>>> LedgerGet(LedgerFilterDTO filter)
    {
        var result = await _client.ApiLedgerFilterAsync(filter);
        return new APIResult<ICollection<LedgerEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadEntity>>> LedgerLoadUpdateType(List<LedgerLoadTypeUpdateDTO> updates)
    {
        var result = await _client.ApiLedgerLoadLoadtoledgerPutAsync(updates);
        return new APIResult<ICollection<LedgerLoadEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<LedgerLoadTypeEntity>>> LedgerLoadTypeGet()
    {
        var result = await _client.ApiLedgerLoadTypeAsync();
        return new APIResult<ICollection<LedgerLoadTypeEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> PhraseDelete(IEnumerable<int> deletes)
    {
        var result = await _client.ApiPhraseDeleteAsync(deletes);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<TagEntity>> TagCreate(string tagName)
    {
        var result = await _client.ApiTagPostAsync(tagName);
        return new APIResult<TagEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult> TagDelete(IEnumerable<int> ids)
    {
        var result = await _client.ApiTagDeleteAsync(ids);
        return new APIResult(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<TagEntity>>> TagGet()
    {
        var result = await _client.ApiTagGetAsync();
        return new APIResult<ICollection<TagEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<TagEntity>>> TagUpdate(IEnumerable<TagUpdateDTO> updates)
    {
        var result = await _client.ApiTagPutAsync(updates);
        return new APIResult<ICollection<TagEntity>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<LedgerEntity>> LedgerAddTags(int ledgerId, List<int> existingTags, List<string> newTags)
    {
        var result = await _client.ApiLedgerTagAsync(ledgerId, new AddTagModel() { ExistingTags = existingTags, NewTags = newTags });
        return new APIResult<LedgerEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<LedgerLoadEntity>> LedgerLoadAddTags(int ledgerLoadId, List<int> existingTags, List<string> newTags)
    {
        var result = await _client.ApiLedgerLoadTagAsync(ledgerLoadId, new AddTagModel() { ExistingTags = existingTags, NewTags = newTags });
        return new APIResult<LedgerLoadEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<PhraseEntity>> PhraseAddTags(int phraseId, List<int> existingTags, List<string> newTags)
    {
        var result = await _client.ApiPhraseTagAsync(phraseId, new AddTagModel() { ExistingTags = existingTags, NewTags = newTags });
        return new APIResult<PhraseEntity>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<ICollection<ICollection<int>>>> PhraseFindOverlaps()
    {
        var result = await _client.ApiPhraseOverlapsAsync();
        return new APIResult<ICollection<ICollection<int>>>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }

    public async Task<APIResult<string>> EnvironmentGet()
    {
        var result = await _client.ApiEnvironmentAsync();
        return new APIResult<string>(
            error: result.Error,
            isSuccess: result.IsSuccess,
            message: result.Message,
            obj: result.Obj,
            cacheChangeDomain: GetCacheChangeDomain(result.CacheChangeDomainFlags));
    }
}
