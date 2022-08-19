using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum Dimension
{
    [EnumMember(Value = "AFFILIATE")] AFFILIATE,
    [EnumMember(Value = "CUSTOMER_CURRENCY")] CUSTOMER_CURRENCY,
    [EnumMember(Value = "CUSTOMER_COUNTRY")] CUSTOMER_COUNTRY,
    [EnumMember(Value = "CUSTOMER_PROVINCE")] CUSTOMER_PROVINCE,
    [EnumMember(Value = "CUSTOMER_LANGUAGE")] CUSTOMER_LANGUAGE,
    [EnumMember(Value = "PRODUCT_SKU")] PRODUCT_SKU,
    [EnumMember(Value = "TRACKING_ID")] TRACKING_ID,
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "VENDOR_CATEGORY")] VENDOR_CATEGORY,
    [EnumMember(Value = "VENDOR_PRODUCT_SKU")] VENDOR_PRODUCT_SKU
}