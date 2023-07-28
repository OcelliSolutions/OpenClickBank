using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
public class TicketsController : TicketsControllerBase
{
    public override Task RefundAmounts(string receipt, string refundType, string refundAmount, string? sku = null) => throw new NotImplementedException();

    public override Task GetTicket(string id, string? action = null, string? comment = null, string? type = null) => throw new NotImplementedException();

    public override Task UpdateTicket(UpdateTicketRequest request, string id, string? action = null, string? comment = null,
        string? type = null) =>
        throw new NotImplementedException();

    public override Task Returned(string id, string? type = null, string? status = null, string? receipt = null,
        string? createDateFrom = null, string? createDateTo = null, string? updateDateFrom = null,
        string? updateDateTo = null, string? closeDateFrom = null, string? closeDateTo = null) =>
        throw new NotImplementedException();

    public override Task List(string? type = null, string? status = null, string? receipt = null, string? createDateFrom = null,
        string? createDateTo = null, string? updateDateFrom = null, string? updateDateTo = null,
        string? closeDateFrom = null, string? closeDateTo = null, int? page = null) =>
        throw new NotImplementedException();

    public override Task Count(string? type = null, string? status = null, string? receipt = null) => throw new NotImplementedException();

    public override Task PartialRefundDataSchema(string type, string reason, string? sku = null, string? comment = null,
        string? refundType = null, string? refundAmount = null, string? retainSubscription = null) =>
        throw new NotImplementedException();

    public override Task CreateTicket(CreateTicketRequest request, string receipt, string type, string reason, string? sku = null,
        string? comment = null, string? refundType = null, string? refundAmount = null, string? retainSubscription = null) =>
        throw new NotImplementedException();
}