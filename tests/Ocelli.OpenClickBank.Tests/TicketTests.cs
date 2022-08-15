namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("TicketTests")]
public class TicketTests : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly TicketMockClient _badRequestMockClient;
    private readonly TicketMockClient _okEmptyMockClient;
    private readonly TicketMockClient _okInvalidJsonMockClient;

    public TicketTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new TicketMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new TicketMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new TicketMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateTicketAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var receipt = string.Empty;
        Skip.If(string.IsNullOrWhiteSpace(receipt), "A receipt was not provided");

        var response =
            await Fixture.ApiKey.ClickBankService.Tickets.CreateTicketAsync(receipt, QueryTicketType.Tech, "Sample");
        _additionalPropertiesHelper.CheckAdditionalProperties(response,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(response == null, "WARN: No data returned. Could not test");
    }
    #endregion Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task GetTicketsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(ticketList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(ticketList?.TicketData == null, "WARN: No data returned. Could not test");
        Skip.If(ticketList.TicketData != null && !ticketList.TicketData.Any(),
            "WARN: No data returned. Could not test");

        var firstTicket = ticketList.TicketData?.First();
        if (firstTicket == null) return;
        var id = firstTicket.TicketId ?? 0;
        var ticket =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketAsync(id);
        _additionalPropertiesHelper.CheckAdditionalProperties(ticket,
            $@"{Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey} (ticket_id: {id})");
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task GetTicketCountAsync_ResultsReturned_ShouldPass()
    {
        var count =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketCountAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(count,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotEqual(0, count);
    }

    //TODO: The required parameter of `receipt` is not available.
    [Fact(Skip = "TODO: The required parameter of `receipt` is not available.")]
    [TestPriority(11)]
    public async Task GetTicketRefundAmountsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var receipt = string.Empty;
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketRefundAmountsAsync(receipt, RefundType.FULL);
        _additionalPropertiesHelper.CheckAdditionalProperties(ticketList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        //Skip.If(ticketList.TicketData == null, "WARN: No data returned. Could not test");
        //Skip.If(ticketList.TicketData != null && !ticketList.TicketData.Any(), "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task UpdateTicketAsync_ResultsReturned_ShouldPass()
    {
        //TODO: figure out where this id comes from
        var id = 0;
        var response = await Fixture.ApiKey.ClickBankService.Tickets.UpdateTicketAsync(id, TicketAction.Close, "Sample", QueryTicketType.Cncl, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    [TestPriority(30)]
    public async Task AcceptReturnFromCustomerAsync_ResultsReturned_ShouldPass()
    {
        //TODO: figure out where this id comes from
        var id = 0;
        var response = await Fixture.ApiKey.ClickBankService.Tickets.AcceptReturnFromCustomerAsync(id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class TicketMockClient : TicketClient, IMockTests
{
    public TicketMockClient(HttpClient httpClient) : base(httpClient)
    {
        BaseUrl = "https://localhost";
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetTicketCountAsync(cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetTicketCountAsync(cancellationToken: CancellationToken.None));
    }
}

