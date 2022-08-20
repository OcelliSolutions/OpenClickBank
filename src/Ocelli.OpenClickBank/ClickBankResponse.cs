namespace Ocelli.OpenClickBank;

public partial class ClickBankResponse
{
    public bool HasMoreData => StatusCode == 206;
}