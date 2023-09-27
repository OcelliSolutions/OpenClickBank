using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TicketSource
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "API")] API,
    [EnumMember(Value = "CUSTOMER_WAM")] CUSTOMER_WAM,
    [EnumMember(Value = "UNKNOWN")] UNKNOWN,
    [EnumMember(Value = "RNFDS_EMAIL")] RNFDS_EMAIL,
    [EnumMember(Value = "CNCLS_EMAIL")] CNCLS_EMAIL,
    [EnumMember(Value = "VENDOR_WAM")] VENDOR_WAM,
    [EnumMember(Value = "VENDOR_ADMIN")] VENDOR_ADMIN,
    [EnumMember(Value = "CSR_ADMIN")] CSR_ADMIN,
    [EnumMember(Value = "SECURITY")] SECURITY,
    [EnumMember(Value = "CSR_WAM")] CSR_WAM,
    [EnumMember(Value = "CONVERSION_PROCESS")] CONVERSION_PROCESS,
    [EnumMember(Value = "BUSINESS_DEVELOPMENT_FORM")] BUSINESS_DEVELOPMENT_FORM,
    [EnumMember(Value = "COMMUNICATIONS_EMAIL")] COMMUNICATIONS_EMAIL,
    [EnumMember(Value = "ACCOUNTS_EMAIL")] ACCOUNTS_EMAIL,
    [EnumMember(Value = "CBCS_EMAIL")] CBCS_EMAIL,
    [EnumMember(Value = "ACCOUNTING_EMAIL")] ACCOUNTING_EMAIL,
    [EnumMember(Value = "WAM_ACCT_QUESTION")] WAM_ACCT_QUESTION,
    [EnumMember(Value = "WAM_WIREGROUP_DETAIL")] WAM_WIREGROUP_DETAIL,
    [EnumMember(Value = "MARKETING_EMAIL")] MARKETING_EMAIL,
    [EnumMember(Value = "PAYMENTECH_BATCH")] PAYMENTECH_BATCH,
    [EnumMember(Value = "PYPL_JPY_CANCELLER")] PYPL_JPY_CANCELLER,
    [EnumMember(Value = "ECUSTOMS")] ECUSTOMS,
    [EnumMember(Value = "LASHBACK")] LASHBACK,
    [EnumMember(Value = "SPAM_EMAIL")] SPAM_EMAIL,
    [EnumMember(Value = "CLICKBANK_DATABASE_SCRIPT")] CLICKBANK_DATABASE_SCRIPT,
    [EnumMember(Value = "API_VIRTUAL_SOURCE")] API_VIRTUAL_SOURCE,
    [EnumMember(Value = "KOUNT")] KOUNT,
    [EnumMember(Value = "PAYPAL_ADAPTIVE")] PAYPAL_ADAPTIVE,
    [EnumMember(Value = "CB_POWERED_PROGRAM")] CB_POWERED_PROGRAM,
    [EnumMember(Value = "CLKBANK")] CLKBANK
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
