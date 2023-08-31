using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="ProductsControllerBase"/>
[ApiController]
[Route("rest")]
[SwaggerTag("The Products API lets you perform CRUD product management operations", "https://api.clickbank.com/rest/1.3/products")]
public class ProductsController : ProductsControllerBase
{
    /// <inheritdoc cref="ProductsControllerBase.GetProduct"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    public override Task GetProduct(string sku, string site) => throw new NotImplementedException();

    /// <inheritdoc cref="ProductsControllerBase.UpdateProduct"/>
    [HttpPut, Route("1.3/products/{sku}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public Task UpdateProduct(string sku, string site, Currency currency, double price,
        Language language, string title, bool? digital = null, bool? physical = null, bool? digitalRecurring = null,
        bool? physicalRecurring = null, ProductCategory? categories = null, bool? skipConfirmationPage = null,
        string? thankYouPage = null, string? mobileThankYouPage = null, double? rebillPrice = null,
        double? rebillCommission = null, int? trialPeriod = null, RecurringFrequency? frequency = null, int? duration = null,
        string? shippingProfile = null, string? purchaseCommission = null, string? description = null, int? image = null,
        string? pitchPage = null, string? mobilePitchPage = null, int? saleRefundDaysLimit = null,
        int? rebillRefundDaysLimit = null, string? deliveryMethod = null, string? deliverySpeed = null,
        bool? preRebillNotificationOverride = null, int? preRebillNotificationLeadTime = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ProductsControllerBase.UpdateProduct"/>
    [HttpPut, Route("1.3/products/{sku}.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task UpdateProduct(string sku, string site, string currency, double price, string language, string title,
        bool? digital = null, bool? physical = null, bool? digitalRecurring = null, bool? physicalRecurring = null,
        string? categories = null, bool? skipConfirmationPage = null, string? thankYouPage = null,
        string? mobileThankYouPage = null, double? rebillPrice = null, double? rebillCommission = null,
        int? trialPeriod = null, string? frequency = null, int? duration = null, string? shippingProfile = null,
        string? purchaseCommission = null, string? description = null, int? image = null, string? pitchPage = null,
        string? mobilePitchPage = null, int? saleRefundDaysLimit = null, int? rebillRefundDaysLimit = null,
        string? deliveryMethod = null, string? deliverySpeed = null, bool? preRebillNotificationOverride = null,
        int? preRebillNotificationLeadTime = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ProductsControllerBase.DeleteProduct"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteProduct(string sku, string site) => throw new NotImplementedException();


    /// <inheritdoc cref="ProductsControllerBase.GetProducts"/>
    [HttpGet, Route("1.3/products/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status206PartialContent)]
    public Task GetProducts(string site, ProductType? type = null, [FromHeader] int? page = null) => throw new NotImplementedException();

    /// <inheritdoc cref="ProductsControllerBase.GetProducts"/>
    [HttpGet, Route("1.3/products/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status206PartialContent)]
    public override Task GetProducts(string site, string? type = null, [FromHeader] int? page = null) => throw new NotImplementedException();
}