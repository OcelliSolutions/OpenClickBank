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
        Skip.If(string.IsNullOrWhiteSpace(Fixture.Receipt), "A receipt was not provided");

        var response =
            await Fixture.ApiKey.ClickBankService.Tickets.CreateTicketAsync(Fixture.Receipt, TicketTypeRequest.RFND, TicketReasonRequest.TICKET_TYPE_REFUND_8, refundType: RefundType.FULL);
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
        Skip.If(ticketList.Result?.TicketData == null, "WARN: No data returned. Could not test");
        Skip.If(ticketList.Result?.TicketData != null && !ticketList.Result.TicketData.Any(),
            "WARN: No data returned. Could not test");

        var firstTicket = ticketList.Result?.TicketData?.First();
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
    [SkippableFact]
    [TestPriority(11)]
    public async Task GetTicketRefundAmountsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketRefundAmountsAsync(Fixture.Receipt, RefundType.PARTIAL_PERCENT, 10);
        _additionalPropertiesHelper.CheckAdditionalProperties(ticketList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        //Skip.If(ticketList.TicketData == null, "WARN: No data returned. Could not test");
        //Skip.If(ticketList.TicketData != null && !ticketList.TicketData.Any(), "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task UpdateTicketAsync_ResultsReturned_ShouldPass()
    {
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketsAsync();
        var id = ticketList.Result?.TicketData?.First()?.TicketId ?? 0;
        var response = await Fixture.ApiKey.ClickBankService.Tickets.UpdateTicketAsync(id, TicketAction.CLOSE, "Sample", TicketTypeRequest.CNCL, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    [TestPriority(30)]
    public async Task AcceptReturnFromCustomerAsync_ResultsReturned_ShouldPass()
    {
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketsAsync();
        var id = ticketList.Result?.TicketData?.FirstOrDefault(t => t?.Type == TicketType.REFUND)?.TicketId ?? 0;
        Skip.If(id == 0, "No testable tickets");
        var response = await Fixture.ApiKey.ClickBankService.Tickets.ReturnedTicketAsync(id);
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

internal class TicketMockClient : TicketsClient, IMockTests
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

