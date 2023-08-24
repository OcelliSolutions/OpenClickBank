//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v10.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#nullable enable

using System.Text.Json;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace Ocelli.OpenClickBank.Builder.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v10.0.0.0))")]
    [Microsoft.AspNetCore.Mvc.Route("rest")]

    public abstract class ProductsControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="site">The site owning product to be deleted</param>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("1.3/products/{sku}")]
        public abstract System.Threading.Tasks.Task DeleteProduct(string sku, [Microsoft.AspNetCore.Mvc.FromQuery] string site);

        /// <summary>
        /// Gets a product
        /// </summary>
        /// <param name="site">The site owning the product to be retrieved.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("1.3/products/{sku}")]
        public abstract System.Threading.Tasks.Task GetProduct(string sku, [Microsoft.AspNetCore.Mvc.FromQuery] string site);

        /// <summary>
        /// Saves a product with the passed in parameters
        /// </summary>
        /// <param name="site">The site owning the product to be saved.</param>
        /// <param name="currency">The currency the product is sold in.</param>
        /// <param name="price">The price for the product.  Or in the case of RECURRING or RECURRING_PHYSICAL products, the initial price.</param>
        /// <param name="language">The language of the product.  Must be either DE (German), EN (English), ES, (Spanish), FR (French), IT (Italian), or PT (Portuguese)</param>
        /// <param name="title">The title of the product</param>
        /// <param name="digital">product has digital component</param>
        /// <param name="physical">product has physical component</param>
        /// <param name="digitalRecurring">product has digital recurring component</param>
        /// <param name="physicalRecurring">product has physical recurring component</param>
        /// <param name="categories">The categories for digital products.  At least one is required for a product with a digital component, multiple may be specified. Must be either EBOOK, SOFTWARE, GAMES, AUDIO, VIDEO, or MEMBER_SITE. Providing a category for a product without a digital component will result in an error.</param>
        /// <param name="skipConfirmationPage">Whether or not to skip confirmation page.  This parameter is role restricted.  If you do not have the role, it will not be honored.</param>
        /// <param name="thankYouPage">The thank you page for desktops. Either thankYouPage or mobileThankYouPage is required</param>
        /// <param name="mobileThankYouPage">The thank you page for mobile devices.</param>
        /// <param name="rebillPrice">In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill price.</param>
        /// <param name="rebillCommission">In the case of RECURRING or RECURRING_PHYSICAL products the rebill commission.</param>
        /// <param name="trialPeriod">In the case of RECURRING or RECURRING_PHYSICAL (required) products the trial period.  Must  be either 0 or a whole number between 3 and 31.</param>
        /// <param name="frequency">In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill frequency. Must be either WEEKLY, BI_WEEKLY, MONTHLY, QUARTERLY, HALF_YEARLY or YEARLY</param>
        /// <param name="duration">In the case of RECURRING or RECURRING_PHYSICAL (required) products the rebill duration.</param>
        /// <param name="shippingProfile">In the case of PHYSICAL or RECURRING_PHYSICAL products the name of the shipping profile</param>
        /// <param name="purchaseCommission">The commission rate for the product - if unspecified the sites commission rate will be used.</param>
        /// <param name="description">In the case of PHYSICAL or RECURRING_PHYSICAL (required) the description of the product.</param>
        /// <param name="image">The id of the image associated to the product</param>
        /// <param name="pitchPage">The URL where you pitch your product. This might be the same as the HopLink Target URL. Either pitchPage or mobilePitchPage is required.</param>
        /// <param name="mobilePitchPage">The URL where you pitch your product to customers on mobile devices. This might be the same as the HopLink Target URL. Either pitchPage or mobilePitchPage is required.</param>
        /// <param name="saleRefundDaysLimit">The number days within which a sale can be refunded</param>
        /// <param name="rebillRefundDaysLimit">The number days within which a rebill can be refunded</param>
        /// <param name="deliveryMethod">The method of delivery.</param>
        /// <param name="deliverySpeed">The speed of delivery.</param>
        /// <param name="preRebillNotificationOverride">When set, Pre-rebill notificaitons will be sent when the frequency is greater than the required cycle.</param>
        /// <param name="preRebillNotificationLeadTime">The number of days before the rebill notification.  When enabled, a Pre-rebill notification will be sent to the number equal to the number of days indicated in the lead time and will apply to the rest of the subscription.</param>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("1.3/products/{sku}")]
        public abstract System.Threading.Tasks.Task UpdateProduct(string sku, [Microsoft.AspNetCore.Mvc.FromQuery] string site, [Microsoft.AspNetCore.Mvc.FromQuery] string currency, [Microsoft.AspNetCore.Mvc.FromQuery] double price, [Microsoft.AspNetCore.Mvc.FromQuery] string language, [Microsoft.AspNetCore.Mvc.FromQuery] string title, [Microsoft.AspNetCore.Mvc.FromQuery] bool? digital = null, [Microsoft.AspNetCore.Mvc.FromQuery] bool? physical = null, [Microsoft.AspNetCore.Mvc.FromQuery] bool? digitalRecurring = null, [Microsoft.AspNetCore.Mvc.FromQuery] bool? physicalRecurring = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? categories = null, [Microsoft.AspNetCore.Mvc.FromQuery] bool? skipConfirmationPage = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? thankYouPage = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? mobileThankYouPage = null, [Microsoft.AspNetCore.Mvc.FromQuery] double? rebillPrice = null, [Microsoft.AspNetCore.Mvc.FromQuery] double? rebillCommission = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? trialPeriod = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? frequency = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? duration = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? shippingProfile = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? purchaseCommission = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? description = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? image = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? pitchPage = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? mobilePitchPage = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? saleRefundDaysLimit = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? rebillRefundDaysLimit = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? deliveryMethod = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? deliverySpeed = null, [Microsoft.AspNetCore.Mvc.FromQuery] bool? preRebillNotificationOverride = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? preRebillNotificationLeadTime = null);

        /// <summary>
        /// Lists all products
        /// </summary>
        /// <param name="site">The site owning the products</param>
        /// <param name="type">The product types to return.d  Must be either STANDARD or RECURRING.  Will return all types if not specified</param>
        /// <param name="page">Page Number. Results only return 100 records at a time</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("1.3/products/list")]
        public abstract System.Threading.Tasks.Task GetProducts([Microsoft.AspNetCore.Mvc.FromQuery] string site, [Microsoft.AspNetCore.Mvc.FromQuery] string? type = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? page = null);

    }

    


}

#pragma warning restore  108
#pragma warning restore  114
#pragma warning restore  472
#pragma warning restore  612
#pragma warning restore 1573
#pragma warning restore 1591
#pragma warning restore 8073
#pragma warning restore 3016
#pragma warning restore 8603