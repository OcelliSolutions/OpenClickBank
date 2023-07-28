using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="ProductsControllerBase"/>
[ApiController]
[Route("rest")]
public class ProductsController : ProductsControllerBase
{
    /// <inheritdoc cref="ProductsControllerBase.GetProduct"/>
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("1.3/products/{sku}")]
    public override Task GetProduct(string sku, string site) => throw new NotImplementedException();

    /// <inheritdoc cref="ProductsControllerBase.UpdateProduct"/>
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("1.3/products/{sku}")]
    public override Task UpdateProduct(UpdateProductRequest request, string sku, string site, string currency, string price,
        string language, string title, string? digital = null, string? physical = null, string? digitalRecurring = null,
        string? physicalRecurring = null, string? categories = null, string? skipConfirmationPage = null,
        string? thankYouPage = null, string? mobileThankYouPage = null, string? rebillPrice = null,
        string? rebillCommission = null, string? trialPeriod = null, string? frequency = null, string? duration = null,
        string? shippingProfile = null, string? purchaseCommission = null, string? description = null, string? image = null,
        string? pitchPage = null, string? mobilePitchPage = null, string? saleRefundDaysLimit = null,
        string? rebillRefundDaysLimit = null, string? deliveryMethod = null, string? deliverySpeed = null,
        string? preRebillNotificationOverride = null, string? preRebillNotificationLeadTime = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    public override Task DeleteProduct(string sku, string site) => throw new NotImplementedException();

    public override Task List(string site, string? type = null, int? page = null) => throw new NotImplementedException();
}