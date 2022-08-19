using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;
[Route("1.3/tickets")]
[ApiController]
[SwaggerTag("The Tickets API lets you create a technical support or refund ticket, and view or update the status of an existing ticket. For refund tickets related to physical products, you can also confirm that you’ve received a returned product", "https://api.clickbank.com/rest/1.3/tickets")]
public class TicketController : ControllerBase
{
    //// TODO: Figure out what the reason parameter is supposed to be. Documentation unclear
    [HttpPost("{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Create a ticket with the passed in parameters. Will return the created ticket if it's successful.")]
    public ActionResult CreateTicket(
        [Required, SwaggerParameter(Description = "A valid receipt id.")] string receipt,
        [FromQuery, SwaggerParameter(Description = "sku/itemNo of the line item. Used to identify individual purchase in multi-item cart purchase.")] string? sku,
        [Required, FromQuery, SwaggerParameter(Description = "The type of the ticket. Must be either 'rfnd', 'cncl' or 'tech'. For 'rfnd' the parameter refundType must also be specified. If the receipt is for a non-recurring product, either 'rfnd' or 'cncl' will automatically refund that sale. For any receipt of a recurring product, a 'rfnd' will refund that receipt AND cancel any future billing, while a 'cncl' will only cancel future billing without issuing any refunds.")] TicketTypeRequest? type,
        [FromQuery, SwaggerParameter(Description = "The comments associated with creating a ticket.")] string? comment,
        [Required, FromQuery, SwaggerParameter(Description = @"The reason associated with the ticket. A ticket reason should be one of the following based on type:
CNCL
ticket.type.cancel.1 (I did not receive additional value for the recurring payments).
ticket.type.cancel.2 (I was not satisfied with the subscription / Subscription did not meet expectations)
ticket.type.cancel.3 (I was unable to get support from the vendor)
ticket.type.cancel.4 (Product was not compatible with my computer)
ticket.type.cancel.5 (I am unable to afford continuing payments for this subscription)
ticket.type.cancel.6 (I did not realize that I accepted the terms for continuing payments)
ticket.type.cancel.7 (Other)
ticket.type.cancel.not.mobile (Product was not compatible with my mobile device.)
RFND
ticket.type.refund.1 (I never received my product)
ticket.type.refund.2 (I was not satisfied with the product. / Product did not meet expectations)
ticket.type.refund.3 (Product was not compatible with my computer)
ticket.type.refund.4 (I was unable to get technical support)
ticket.type.refund.5 (I did not authorize the purchase)
ticket.type.refund.6 (I do not recognize the purchase)
ticket.type.refund.7 (Duplicate purchase. / Or already purchased product previously)
ticket.type.refund.returned (Product returned)
ticket.type.refund.8 (Other)
ticket.type.refund.not.mobile (Product was not compatible with my mobile device.)
TECH
ticket.type.tech_support.1 (I am unable to log in.)
ticket.type.tech_support.2 (I had problems downloading the product.)
ticket.type.tech_support.3 (I never received a valid registration code, please send a valid code.)
ticket.type.tech_support.4 (I can't get the product to work.)
ticket.type.tech_support.9 (Other)
ticket.type.tech_support.10 (I never received my product.)")] TicketReasonRequest? reason,
        [FromQuery, SwaggerParameter(Description = "The type of refund. Supported values include 'FULL', 'PARTIAL_PERCENT', 'PARTIAL_AMOUNT' (case sensitive). For 'PARTIAL_PERCENT' and 'PARTIAL_AMOUNT' the parameter refundAmount must be specified. Additionally the vendor associated with the transaction must be enabled for partial refunds in order to use both 'PARTIAL_PERCENT' and 'PARTIAL_AMOUNT', if vendor is not enabled and one of the partial options is specified a 403 will be returned.")] RefundType? refundType,
        [FromQuery, SwaggerParameter(Description = "Specified for partial refunds indicating the amount of the transaction to be refunded. For 'PARTIAL_PERCENT' this must be a number between 1 and 80, with no more than two digits of precision - for example 50.00. For 'PARTIAL_AMOUNT' this is the amount to refund in the currency the customer used during the purchase. The resource /1.3/tickets/refundAmounts may be used to retrieve what amounts in the customers currency convert to.")] decimal? refundAmount,
        [FromQuery, SwaggerParameter(Description = "Specifies if the subscription should be retained after the refund has been processed.")] bool? retainSubscription) => Ok();

    [HttpGet("refundAmounts/{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ })]
    [ProducesResponseType(typeof(PartialRefundData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Returns amounts that would be refunded for a given refund type & value.")]
    public ActionResult GetTicketRefundAmounts(
        [Required, SwaggerParameter(Description = "A valid receipt id.")] string receipt,
        [Required, SwaggerParameter(Description = "The type of refund. Supported values include 'FULL', 'PARTIAL_PERCENT', 'PARTIAL_AMOUNT' (case sensitive). For 'PARTIAL_PERCENT' and 'PARTIAL_AMOUNT' the parameter refundAmount must be specified. Additionally the vendor associated with the transaction must be enabled for partial refunds in order to use both 'PARTIAL_PERCENT' and 'PARTIAL_AMOUNT', if vendor is not enabled and one of the partial options is specified a 403 will be returned.")] RefundType refundType,
        [SwaggerParameter(Description = "Specified for partial refunds indicating the amount of the transaction to be refunded. For 'PARTIAL_PERCENT' this must be a number between 1 and 80, with no more than two digits of precision - for example 50.00. For 'PARTIAL_AMOUNT' this is the amount to refund in the currency the customer used during the purchase.")] decimal? refundAmount,
        [SwaggerParameter(Description = "line item sku/itemNo.")] string? sku) => Ok();

    [HttpGet("{id}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Find a ticket by its ID. Will return the ticket with the given ID back. If the ticket does not exist, or the user is not authorized to view the ticket - a status code of 403 will be returned.")]
    public ActionResult GetTicket(
        [Required, SwaggerParameter(Description = "A valid ticket id.")] int id) => Ok();

    [HttpPut("{id}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Allows the user to close a ticket, comment on a ticket, change type of a ticket, or reopen the ticket. Will return a status code 200 if the action is successful, a 403 if user is not allowed to act on the ticket or the ticket does not exist. Upon success, this will return the ticket data. Please note that closing of a ticket manually means that the ticket is cancelled. So for example closing of an open refund ticket will cancel the refund request. If the action is not specified, the assumption is that the user is trying to comment on the ticket. Also note that reopening is only supported for closed tickets and will return a 400 status code otherwise.")]
    public ActionResult UpdateTicket(
        [Required, SwaggerParameter(Description = "A valid ticket id.")] int id,
        [FromQuery, SwaggerParameter(Description = "The action to be taken. Supported actions are 'change', 'close' and 'reopen'.")] TicketAction? action,
        [FromQuery, SwaggerParameter(Description = "The comments that go along with the action, or comments on the ticket. Comments are required when reopening a ticket.")] string? comment,
        [FromQuery, SwaggerParameter(Description = "If changing the type of the ticket, this will be one of rfnd, cncl, or tech. Note: Partial refunds are not allowed when changing to a rfnd ticket type. Tickets changed to rfnd will be full refunds.")] TicketTypeRequest? type) => Ok();

    [HttpPost("{id}/returned")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeData), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "Acknowledges return of physical item from customer, allowing refund of transaction to complete. This call will return a status code of 204 if successful. The body of the response will be empty in this case. A 403 (Forbidden) status code will be return if access is denied. A 400 (Bad Request) will be returned if the ticket isn't found or the ticket is not for a physical purchase.")]
    public ActionResult AcceptReturnFromCustomer(
        [Required, SwaggerParameter(Description = "A valid ticket id.")] int id) => NoContent();

    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(TicketList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(TicketList), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = "Searches for tickets matching the search criteria. Will return a list of ticket data objects with a status code of 200. If more than 100 results are returned, it will return a status code of 206 [Partial Content]. Users can then use the 'Page' header to determine the page needed.")]
    public ActionResult GetTickets(
        [FromQuery, SwaggerParameter(Description = "The type of the ticket. Must be either 'rfnd' / 'cncl' or 'tech'.")] TicketTypeRequest? type,
        [FromQuery, SwaggerParameter(Description = "The status of the ticket. Can be 'open', 'reopened' or 'closed'.")] TicketStatus? status,
        [FromQuery, SwaggerParameter(Description = "Find a ticket by a given receipt. Will return the ticket(s) associated with the transaction. If the receipt is a subscription, all tickets with associated with each rebill of that subscription will be returned. Must be 4 or more characters in length, not counting the wildcard character ('%'). May not start with the wildcard character.")] string? receipt,
        [FromQuery, SwaggerParameter(Description = "The start of the createDate range to filter tickets by. If you provide a 'createDateFrom', you must also provide a 'createDateTo' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? createDateFrom,
        [FromQuery, SwaggerParameter(Description = "The end of the createDate range to filter tickets by. If you provide a 'createDateTo', you must also provide a 'createDateFrom' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? createDateTo,
        [FromQuery, SwaggerParameter(Description = "The start of the updateDate range to filter tickets by. If you provide a 'createDateTo', you must also provide a 'createDateFrom' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? updateDateFrom,
        [FromQuery, SwaggerParameter(Description = "The end of the updateDate range to filter tickets by. If you provide a 'createDateTo', you must also provide a 'createDateFrom' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? updateDateTo,
        [FromQuery, SwaggerParameter(Description = "The start of the closeDate range to filter tickets by. If you provide a 'createDateTo', you must also provide a 'createDateFrom' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? closeDateFrom,
        [FromQuery, SwaggerParameter(Description = "The end of the closeDate range to filter tickets by. If you provide a 'createDateTo', you must also provide a 'createDateFrom' to complete the date range. The range cannot be more than 7 days in length. Dates must be in the format 'yyyy-mm-dd', i.e '2011-12-31' for December 31st, 2011.")] DateTime? closeDateTo,
        [FromHeader, SwaggerParameter(Description = "Page Number. Results only return 100 records at a time.")] int? page = 1) => Ok();


    [HttpGet("count")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Counts the tickets matching the search criteria.")]
    public ActionResult GetTicketCount(
        [FromQuery, SwaggerParameter(Description = "The type of the ticket. Must be either 'rfnd' / 'cncl' or 'tech'.")] TicketTypeRequest? type,
        [FromQuery, SwaggerParameter(Description = "The status of the ticket. Can be 'open', 'reopened' or 'closed'.")] TicketStatus? status,
        [FromQuery, SwaggerParameter(Description = "Counts a ticket by a given receipt. Will return the ticket(s) associated with the transaction. If the receipt is a subscription, all tickets with associated with each rebill of that subscription will be counted.")] string? receipt) => Ok();
}
