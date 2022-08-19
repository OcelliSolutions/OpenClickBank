using System.ComponentModel.DataAnnotations;

namespace Ocelli.OpenClickBank;

public enum NotificationTransactionType
{
    nil,
    [Display(Name = "SALE")] SALE,
    [Display(Name = "BILL")] BILL,
    [Display(Name = "RFND")] RFND,
    [Display(Name = "CGBK")] CGBK,
    [Display(Name = "INSF")] INSF,
    [Display(Name = "CANCEL-REBILL")] CANCEL_REBILL,
    [Display(Name = "UNCANCEL-REBILL")] UNCANCEL_REBILL,
    [Display(Name = "SUBSCRIPTION-CHG")] SUBSCRIPTION_CHG,
    [Display(Name = "ABANDONED_ORDER")] ABANDONED_ORDER,

    [Display(Name = "CUSTOMER_AUTH_FAILURE")]
    CUSTOMER_AUTH_FAILURE,

    [Display(Name = "CUSTOMER_EMAIL_UPDATE")]
    CUSTOMER_EMAIL_UPDATE,

    [Display(Name = "CUSTOMER_UPDATE_CC_NOTIFICATION")]
    CUSTOMER_UPDATE_CC_NOTIFICATION,

    [Display(Name = "PURCHASE_DETAILS_EMAIL_RESPONSE")]
    PURCHASE_DETAILS_EMAIL_RESPONSE,
    [Display(Name = "TEST")] TEST,
    [Display(Name = "TEST_BILL")] TEST_BILL,
    [Display(Name = "TEST_RFND")] TEST_RFND,
    [Display(Name = "TEST_SALE")] TEST_SALE,
    [Display(Name = "CANCEL-TEST-REBILL")] CANCEL_TEST_REBILL,

    [Display(Name = "UNCANCEL-TEST-REBILL")]
    UNCANCEL_TEST_REBILL
}