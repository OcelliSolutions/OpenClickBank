namespace Ocelli.OpenClickBank;

public partial class ClickBankService : IDebugClient
{
    public Task<string> GetDebugAsync(CancellationToken cancellationToken = default) => Debugs.GetDebugAsync(cancellationToken);
}