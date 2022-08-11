using System.ComponentModel.DataAnnotations;

namespace Ocelli.OpenClickBank;

public enum PaymentMethod
{
    nil,
    [Display(Name = "PYPL")]
    PYPL,
    [Display(Name = "PYPL-NEW")]
    PYPL_NEW,
    [Display(Name = "VISA")]
    VISA,
    [Display(Name = "MSTR")]
    MSTR,
    [Display(Name = "DISC")]
    DISC,
    [Display(Name = "AMEX")]
    AMEX,
    [Display(Name = "DNRS")]
    DNRS,
    [Display(Name = "MAES")]
    MAES,
    [Display(Name = "TEST")]
    TEST,
}
