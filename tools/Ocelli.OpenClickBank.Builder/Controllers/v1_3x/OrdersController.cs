using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

[Route("1.3/orders2")]
[ApiController]
[SwaggerTag("The Orders API lets you view order information and update some order parameters", "https://api.clickbank.com/rest/1.3/orders2")]
public class OrdersManualController : ControllerBase
{
    [HttpGet("{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Returns a list of order detail objects which match the given receipt.")]
    public ActionResult GetOrder(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [FromQuery, SwaggerParameter(Description = "sku/itemNo of the line item. Used to identify individual purchase in multi-item cart purchase.")] string? sku) => Ok();

    [HttpGet("{receipt}/upsells")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = @"Returns all the upsell transactions for the given parent upsell transaction.
If the transaction does not exist, or the user does not have access to the transaction, or if there are no upsells for this transaction, a status code of 403 (No Content) will be returned.")]
    public ActionResult GetOrderUpsells(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt) => Ok();

    [HttpGet("count")]
    [Authorize]
    [Produces("text/plain")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Same as the list command, except that this one returns the count of the orders returned based on the search criteria.")]
    public ActionResult GetOrderCount(
        [FromQuery, SwaggerParameter(Description = "The affiliate name. Supports the word 'none' to search for transactions without affiliates, and wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? affiliate,
        [FromQuery, SwaggerParameter(Description = "The item number of the order.")] string? item,
        [FromQuery, SwaggerParameter(Description = "The email of the customer. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? email,
        [FromQuery, SwaggerParameter(Description = "Customers last name. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? lastName,
        [FromQuery, SwaggerParameter(Description = "Role account was of transaction options are [VENDOR, AFFILIATE].")] RoleAccount? role,
        [FromQuery, SwaggerParameter(Description = "The beginning date for the search (yyyy-mm-dd).")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "The end date for the search (yyyy-mm-dd).")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "The TID (Tracking ID / Promo Code) to search on. This will search both vendor and affiliate tracking codes and be returned in the promo field.")] string? tid,
        [FromQuery, SwaggerParameter(Description = "The type of transactions to be returned. Supported types are [SALE / RFND / CGBK / FEE / BILL / TEST_SALE / TEST_BILL / TEST_RFND /TEST_FEE]. If not specified all types will be returned. If an invalid type is specified, no transactions will be returned.")] TransactionType? type,
        [FromQuery, SwaggerParameter(Description = "The vendor name. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? vendor) => Ok();

    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"List orders for the authenticated user scoped to the search criteria. Only the first 100 orders will be returned. This method supports pagination, so if the second page of the next 100 items is required a request header 'Page' with value 2 will return them.
This method will return 200 if all the receipts have been obtained, or a 206 [Partial Return] if there are more results available.")]
    public ActionResult GetOrders(
        [FromQuery, SwaggerParameter(Description = "The affiliate name. Supports the word 'none' to search for transactions without affiliates, and wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? affiliate,
        [FromQuery, SwaggerParameter(Description = "The transaction total amount.")] decimal? amount,
        [FromQuery, SwaggerParameter(Description = "The email of the customer. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? email,
        [FromQuery, SwaggerParameter(Description = "The item number of the order.")] string? item,
        [FromQuery, SwaggerParameter(Description = "Customers last name. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? lastName,
        [FromQuery, SwaggerParameter(Description = "Customer's zip or postal code. Supports wildcard searches.")] string? postalCode,
        [FromQuery, SwaggerParameter(Description = "Role account was of transaction options are [VENDOR, AFFILIATE].")] RoleAccount? role,
        [FromQuery, SwaggerParameter(Description = "The beginning date for the search (yyyy-mm-dd). If a startDate is specified, you must also specify an endDate.")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "The end date for the search (yyyy-mm-dd). If an endDate is specified, you must also specify a startDate.")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "The TID (Tracking ID / Promo Code) to search on. This will search both vendor and affiliate tracking codes and be returned in the promo field.")] string? tid, [FromQuery, SwaggerParameter(Description = "The type of transactions to be returned. Supported types are [SALE / RFND / CGBK / FEE / BILL / TEST_SALE / TEST_BILL / TEST_RFND /TEST_FEE]. If not specified all types will be returned. If an invalid type is specified, no transactions will be returned.")] TransactionType? type,
        [FromQuery, SwaggerParameter(Description = "The vendor name. Supports wildcard searches using the '%' character. (Wildcards are converted to %25 after url encoding is done by the client)")] string? vendor,
        [FromHeader, SwaggerParameter(Description = "This method supports pagination, so if the second page of the next 100 items is required a request header 'Page' with value 2 will return them")] int? page = 1) => Ok();

    [HttpPost("{receipt}/changeProduct")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "*BETA* Allows a vendor to change (upgrade or downgrade) the product associated with a subscription.")]
    public ActionResult ChangeOrderProduct(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [Required, FromQuery, SwaggerParameter(Description = "The SKU of the new product for the subscription.")] string newSku,
        [Required, FromQuery, SwaggerParameter(Description = "The SKU of the current product for the subscription.")] string oldSku,
        [FromQuery, SwaggerParameter(Description = "Determines if the affiliate from the original transaction is carried over to the new subscription.")] string? carryAffiliate,
        [FromQuery, SwaggerParameter(Description = "Determines if the pro rated refund should be applied on the product change. This parameter will default to TRUE if not explicitly set.")] bool? applyProratedRefund,
        [FromQuery, SwaggerParameter(Description = "Allows the vendor to change the date of the next rebill. Date Format is YYYY-MM-DD. Not passing in any value will set the next rebill date to the next day of product change.")] DateTime? nextRebillDate) => NoContent();

    [HttpPost("{receipt}/changeAddress")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "Allows a vendor to change shipping address of a physical recurring subscription.")]
    public ActionResult ChangeOrderAddress(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [FromQuery, SwaggerParameter(Description = "Updated customer first name.")] string? firstName,
        [FromQuery, SwaggerParameter(Description = "Updated customer last name.")] string? lastName,
        [Required, FromQuery, SwaggerParameter(Description = "Updated address (line 1).")] string address1,
        [FromQuery, SwaggerParameter(Description = "Updated address (line 2).")] string? address2,
        [Required, FromQuery, SwaggerParameter(Description = "Updated city.")] string city,
        [FromQuery, SwaggerParameter(Description = "Updated county.")] string? county,
        [FromQuery, SwaggerParameter(Description = "Updated state or province.")] string? province,
        [Required, FromQuery, SwaggerParameter(Description = "Updated country code.")] string countryCode,
        [FromQuery, SwaggerParameter(Description = "Updated postal code or Zip.")] string? postalCode) => NoContent();

    [HttpPost("{receipt}/changeDate")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "*BETA* Allows a vendor to change the rebill date of a subscription.")]
    public ActionResult ChangeOrderDate(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [Required, FromQuery, SwaggerParameter(Description = "The date on which the next payment will be made. This date must be in the future. The date format is yyyy-mm-dd.")] DateTime? changeDate,
        [FromQuery, SwaggerParameter(Description = "sku/itemNo of the line item. Used to identify individual purchase in multi-item cart purchase.")] string? sku) => Ok();

    [HttpPost("{receipt}/extend")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "*BETA* Allows a vendor to extend a subscription by a given number of rebill periods.")]
    public ActionResult ExtendOrder(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [Required, FromQuery, SwaggerParameter(Description = "The number of periods to extend the subscription by.")] int numPeriods,
        [FromQuery, SwaggerParameter(Description = "sku/itemNo of the line item. Used to identify individual purchase in multi-item cart purchase.")] string? sku) => NoContent();

    [HttpPost("{receipt}/pause")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "*BETA* Allows a vendor to change the rebill date of a subscription.")]
    public ActionResult PauseOrder(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [Required, FromQuery, SwaggerParameter(Description = "The date when the subscription will be resumed in format yyyy-mm-dd")] DateTime restartDate,
        [FromQuery, SwaggerParameter(Description = "The item number of the subscription product that should be reinstated for the order.")] string? sku) => NoContent();

    [HttpPost("{receipt}/reinstate")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "*BETA* Allows a vendor to restart a cancelled subscription.")]
    public ActionResult ReinstateOrder(
        [Required][SwaggerParameter(Description = "Receipt ID")] string receipt,
        [FromQuery, SwaggerParameter(Description = "The item number of the subscription product that should be reinstated for the order.")] string? sku) => NoContent();

    [HttpHead("{receipt}")]
    [Authorize]
    [Produces("application/xml", "application/json")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = "This head request is used to identify if a particular order or a subscription is active, i.e. it has not been refunded, charge-backed or cancelled. It will return a 403 (Forbidden) if that's the case, or a 204 if the order is still active. Note that it will also return a 403 if the order is not found, or the user does not have access to that receipt. In addition, head request on a rebill transaction will return the status of that particular rebill, not of the original transaction which may be different. It is advisable to use head requests only on the parent transactions")]
    public ActionResult IsActiveOrderOrSubscription([Required][SwaggerParameter(Description = "Receipt ID")] string receipt,
        [SwaggerParameter(Description = "sku/itemNo of the line item. Used to identify individual purchase in multi-item cart purchase")] string? sku) => NoContent();
}
