using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;
[Route("1.3/products")]
[ApiController]
[SwaggerTag("The Products API lets you perform CRUD product management operations", "https://api.clickbank.com/rest/1.3/products")]
public class ProductManualController : ControllerBase
{
    [HttpGet("{sku}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Gets a product.")]
    public ActionResult GetProduct(
        [Required, SwaggerParameter(Description = "The product sku.")] string sku,
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the product to be retrieved.")] string site) => Ok();

    [HttpDelete("{sku}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(Summary = @"Delete a product.")]
    public ActionResult DeleteProduct(
        [Required, SwaggerParameter(Description = "The product sku.")] string sku,
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the product to be retrieved.")] string site) => Ok();

    [HttpPut("{sku}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(Summary = @"Saves a product with the passed in parameters.")]
    public ActionResult CreateProduct(
        [Required, SwaggerParameter(Description = "The product sku.")] string sku,
        [FromQuery, SwaggerParameter(Description = "Product has digital component.")] bool? digital,
        [FromQuery, SwaggerParameter(Description = "Product has physical component.")] bool? physical,
        [FromQuery, SwaggerParameter(Description = "Product has digital recurring component.")] bool? digitalRecurring,
        [FromQuery, SwaggerParameter(Description = "Product has physical recurring component.")] bool? physicalRecurring,
        [FromQuery, SwaggerParameter(Description = "The categories for digital products. At least one is required for a product with a digital component, multiple may be specified. Providing a category for a product without a digital component will result in an error.")] ProductCategory[]? categories,
        [FromQuery, SwaggerParameter(Description = "The site owning the product to be saved.")] bool? skipConfirmationPage,
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the product to be saved.")] string site,
        [FromQuery, SwaggerParameter(Description = "The thank you page for desktops. Either thankYouPage or mobileThankYouPage is required.")] string? thankYouPage,
        [FromQuery, SwaggerParameter(Description = "The thank you page for mobile devices.")] string? mobileThankYouPage,
        [Required, FromQuery, SwaggerParameter(Description = "The currency the product is sold in.")] Currency currency,
        [Required, FromQuery, SwaggerParameter(Description = "The price for the product. Or in the case of RECURRING or RECURRING_PHYSICAL products, the initial price.")] decimal price,
        [FromQuery, SwaggerParameter(Description = "In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill price.")] decimal? rebillPrice,
        [FromQuery, SwaggerParameter(Description = "In the case of RECURRING or RECURRING_PHYSICAL products the rebill commission.")] decimal? rebillCommission,
        [FromQuery, SwaggerParameter(Description = "In the case of RECURRING or RECURRING_PHYSICAL (required) products the trial period. Must be either 0 or a whole number between 3 and 31."), Range(0, 31)] int? trialPeriod,
        [FromQuery, SwaggerParameter(Description = "In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill frequency. Must be either WEEKLY, BI_WEEKLY, MONTHLY, QUARTERLY, HALF_YEARLY or YEARLY.")] RecurringFrequency? frequency,
        [FromQuery, SwaggerParameter(Description = "In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill duration.")] int? duration,
        [FromQuery, SwaggerParameter(Description = "In the case of PHYSICAL or RECURRING_PHYSICAL products the name of the shipping profile.")] string? shippingProfile,
        [FromQuery, SwaggerParameter(Description = "The commission rate for the product - if unspecified the sites commission rate will be used.")] decimal? purchaseCommission,
        [Required, FromQuery, SwaggerParameter(Description = "The language of the product. Must be either DE (German), EN (English), ES, (Spanish), FR (French), IT (Italian), or PT (Portuguese).")] Language language,
        [Required, FromQuery, SwaggerParameter(Description = "The title of the product.")] string? title,
        [FromQuery, SwaggerParameter(Description = "In the case of PHYSICAL or RECURRING_PHYSICAL (required) the description of the product.")] string? description,
        [FromQuery, SwaggerParameter(Description = "The id of the image associated to the product.")] int? image,
        [FromQuery, SwaggerParameter(Description = "The URL where you pitch your product. This might be the same as the HopLink Target URL. Either pitchPage or mobilePitchPage is required.")] string? pitchPage,
        [FromQuery, SwaggerParameter(Description = "The URL where you pitch your product to customers on mobile devices. This might be the same as the HopLink Target URL. Either pitchPage or mobilePitchPage is required.")] string? mobilePitchPage,
        [FromQuery, SwaggerParameter(Description = "The number days within which a sale can be refunded.")] int? saleRefundDaysLimit,
        [FromQuery, SwaggerParameter(Description = "The number days within which a rebill can be refunded.")] int? rebillRefundDaysLimit,
        [FromQuery, SwaggerParameter(Description = "The method of delivery.")] string? deliveryMethod,
        [FromQuery, SwaggerParameter(Description = "The speed of delivery.")] string? deliverySpeed,
        [FromQuery, SwaggerParameter(Description = "When set, Pre-rebill notifications will be sent when the frequency is greater than the required cycle.")] bool? preRebillNotificationOverride,
        [FromQuery, SwaggerParameter(Description = "The number of days before the rebill notification. When enabled, a Pre-rebill notification will be sent to the number equal to the number of days indicated in the lead time and will apply to the rest of the subscription.")] int? preRebillNotificationLeadTime
        ) => Ok();

    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"Lists all products.")]
    public ActionResult GetProducts(
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the products.")] string site,
        [FromQuery, SwaggerParameter(Description = "The product types to return.d Must be either STANDARD or RECURRING. Will return all types if not specified.")] ProductType? type,
        [FromHeader, SwaggerParameter(Description = "Page Number. Results only return 100 records at a time.")] int? page = 1) => Ok();
}
