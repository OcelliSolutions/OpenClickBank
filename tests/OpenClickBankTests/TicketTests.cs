using System.Linq;
using OpenClickBank;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class TicketTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public TicketTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    
    [SkippableFact]
    async public void GetTicketsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(ticketList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(ticketList.TicketData == null, "WARN: No data returned. Could not test");
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

    [Fact]
    async public void GetTicketCountAsync_ResultsReturned_ShouldPass()
    {
        var count =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketCountAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(count,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotEqual(0, count);
    }

    //TODO: The required parameter of `receipt` is not available.
    [Fact(Skip = "TODO: The required parameter of `receipt` is not available.")]
    async public void GetTicketRefundAmountsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var receipt = string.Empty;
        var ticketList =
            await Fixture.ApiKey.ClickBankService.Tickets.GetTicketRefundAmountsAsync(receipt, RefundType.FULL);
        _additionalPropertiesHelper.CheckAdditionalProperties(ticketList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        //Skip.If(ticketList.TicketData == null, "WARN: No data returned. Could not test");
        //Skip.If(ticketList.TicketData != null && !ticketList.TicketData.Any(), "WARN: No data returned. Could not test");
    }
}
