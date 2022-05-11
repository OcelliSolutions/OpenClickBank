namespace Ocelli.OpenClickBank;

public partial class ClickBankService : IProductClient
{
    public Task<Product?> GetProductAsync(string sku, string site,
        CancellationToken cancellationToken = default) =>
        Products.GetProductAsync(sku, site, cancellationToken);

    public Task DeleteProductAsync(string sku, string site,
        CancellationToken cancellationToken = default) =>
        Products.DeleteProductAsync(sku, site, cancellationToken);

    public Task<Product?> CreateProductAsync(string sku, string site, string currency, double price, string title,
        bool? digital = null,
        bool? physical = null, bool? digitalRecurring = null, bool? physicalRecurring = null,
        IEnumerable<ProductCategory>? categories = null, bool? skipConfirmationPage = null, string? thankYouPage = null,
        string? mobileThankYouPage = null, double? rebillPrice = null, double? rebillCommission = null,
        int? trialPeriod = null, RecurringFrequency? frequency = null, int? duration = null,
        string? shippingProfile = null,
        double? purchaseCommission = null, Language? language = null, string? description = null, int? image = null,
        string? pitchPage = null, string? mobilePitchPage = null, int? saleRefundDaysLimit = null,
        int? rebillRefundDaysLimit = null, string? deliveryMethod = null, string? deliverySpeed = null,
        bool? preRebillNotificationOverride = null, int? preRebillNotificationLeadTime = null,
        CancellationToken cancellationToken = default) =>
        Products.CreateProductAsync(sku, site, currency, price, title, digital, physical, digitalRecurring,
            physicalRecurring, categories, skipConfirmationPage, thankYouPage, mobileThankYouPage, rebillPrice,
            rebillCommission, trialPeriod, frequency, duration, shippingProfile, purchaseCommission, language,
            description, image, pitchPage, mobilePitchPage, saleRefundDaysLimit, rebillRefundDaysLimit, deliveryMethod,
            deliverySpeed, preRebillNotificationOverride, preRebillNotificationLeadTime, cancellationToken);

    public Task<ProductList?> GetProductsAsync(string? site, ProductType? type = null,
        int? page = 1, CancellationToken cancellationToken = default) =>
        Products.GetProductsAsync(site, type, page, cancellationToken);
}