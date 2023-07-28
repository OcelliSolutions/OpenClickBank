using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="TicketsControllerBase" />
[ApiController]
[SwaggerTag(
    "The Tickets API lets you create a technical support or refund ticket, and view or update the status of an existing ticket. For refund tickets related to physical products, you can also confirm that you’ve received a returned product",
    "https://api.clickbank.com/rest/1.3/tickets")]
public class TicketsController : TicketsControllerBase
{
    /// <inheritdoc cref="TicketsControllerBase.CreateTicket" />
    [HttpPost]
    [Route("1.3/tickets/{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    public Task CreateTicket(string receipt, TicketTypeRequest type, TicketReasonRequest reason, string? sku = null,
        string? comment = null,
        RefundType? refundType = null, double? refundAmount = null, bool? retainSubscription = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.CreateTicket" />
    [HttpPost]
    [Route("1.3/tickets/{receipt}.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    override public Task CreateTicket(string receipt, string type, string reason, string? sku = null,
        string? comment = null,
        string? refundType = null, double? refundAmount = null, bool? retainSubscription = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTicket" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    override public Task GetTicket(int id) => throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTicketCount" />
    [HttpGet]
    [Route("1.3/tickets/count")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task GetTicketCount(TicketTypeRequest? type = null, string? status = null, string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTicketCount" />
    [HttpGet]
    [Route("1.3/tickets/count.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetTicketCount(string? type = null, string? status = null, string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTickets" />
    [HttpGet]
    [Route("1.3/tickets/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(TicketList), StatusCodes.Status206PartialContent)]
    public Task GetTickets(TicketTypeRequest? type = null, string? status = null, string? receipt = null,
        DateTime? createDateFrom = null,
        DateTime? createDateTo = null, DateTime? updateDateFrom = null, DateTime? updateDateTo = null,
        DateTime? closeDateFrom = null, DateTime? closeDateTo = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTickets" />
    [HttpGet]
    [Route("1.3/tickets/list.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetTickets(string? type = null, string? status = null, string? receipt = null,
        DateTime? createDateFrom = null,
        DateTime? createDateTo = null, DateTime? updateDateFrom = null, DateTime? updateDateTo = null,
        DateTime? closeDateFrom = null, DateTime? closeDateTo = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTicketRefundAmounts" />
    [HttpGet]
    [Route("1.3/tickets/refundAmounts/{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ })]
    [ProducesResponseType(typeof(PartialRefundData), StatusCodes.Status200OK)]
    public Task GetTicketRefundAmounts(string receipt, RefundType refundType, double refundAmount, string? sku = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.GetTicketRefundAmounts" />
    [HttpGet]
    [Route("1.3/tickets/refundAmounts/{receipt}.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetTicketRefundAmounts(string receipt, string refundType, double refundAmount,
        string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.ReturnedTicket" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[]
    {
        ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY
    })]
    [ProducesResponseType(typeof(ShippingNoticeList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task ReturnedTicket(int id) => throw new NotImplementedException();


    /// <inheritdoc cref="TicketsControllerBase.UpdateTicket" />
    [HttpPut]
    [Route("1.3/tickets/{id}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[]
    {
        ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY
    })]
    [ProducesResponseType(typeof(ShippingNoticeList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task UpdateTicket(int id, TicketAction? action = null, string? comment = null,
        TicketTypeRequest? type = null) => throw new NotImplementedException();

    /// <inheritdoc cref="TicketsControllerBase.UpdateTicket" />
    [HttpPut]
    [Route("1.3/tickets/{id}.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    override public Task UpdateTicket(int id, string? action = null, string? comment = null, string? type = null) =>
        throw new NotImplementedException();
}