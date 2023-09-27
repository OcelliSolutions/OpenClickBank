namespace Ocelli.OpenClickBank.Tests.Models;

public class ApiKey
{
    private OpenClickBankConfig _openClickBankConfig = null!;
    internal ClickBankService ClickBankService = new() { OpenClickBankConfig = new OpenClickBankConfig() };

    public ApiKey(OpenClickBankConfig openClickBankConfig)
    {
        DaysToTest = 1;
#if DEBUG
        DaysToTest = 10;
#endif
        OpenClickBankConfig = openClickBankConfig;
        if (openClickBankConfig.DeveloperApiKey.EndsWith("xx")) return;
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
            //ClickBankService = new ClickBankService(value);
            ClickBankService = new ClickBankService { OpenClickBankConfig = value };
        }
    }

    public int DaysToTest { get; set; }
    public string Site { get; set; } = string.Empty;
}
