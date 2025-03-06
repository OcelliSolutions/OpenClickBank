namespace Ocelli.OpenClickBank.Tests.Models;

public class ApiKey
{
    private readonly IClickBankServiceFactory _clickBankServiceFactory;
    private OpenClickBankConfig _openClickBankConfig = null!;
    internal IClickBankService ClickBankService { get; private set; }

    public ApiKey(IClickBankServiceFactory clickBankServiceFactory, OpenClickBankConfig openClickBankConfig)
    {
        _clickBankServiceFactory = clickBankServiceFactory ?? throw new ArgumentNullException(nameof(clickBankServiceFactory));
        DaysToTest = 1;
#if DEBUG
        DaysToTest = 10;
#endif
        OpenClickBankConfig = openClickBankConfig;

        try
        {
            var account = ClickBankService.Quickstats.GetQuickstatAccountsAsync().Result;
            Site = account?.AccountData?.First().NickName ??
                   throw new InvalidOperationException("No account is associated with these credentials.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public OpenClickBankConfig OpenClickBankConfig
    {
        get => _openClickBankConfig;
        set
        {
            _openClickBankConfig = value;
            ClickBankService = _clickBankServiceFactory.Create(value);
        }
    }

    public int DaysToTest { get; set; }
    public string Site { get; set; } = string.Empty;
}