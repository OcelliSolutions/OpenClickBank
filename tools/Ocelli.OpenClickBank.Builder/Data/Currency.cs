using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum Currency
{
    [EnumMember(Value = "ARS")] ARS,
    [EnumMember(Value = "AUD")] AUD,
    [EnumMember(Value = "CAD")] CAD,
    [EnumMember(Value = "CHF")] CHF,
    [EnumMember(Value = "CLP")] CLP,
    [EnumMember(Value = "CNY")] CNY,
    [EnumMember(Value = "COP")] COP,
    [EnumMember(Value = "CZK")] CZK,
    [EnumMember(Value = "DKK")] DKK,
    [EnumMember(Value = "EUR")] EUR,
    [EnumMember(Value = "GBP")] GBP,
    [EnumMember(Value = "HKD")] HKD,
    [EnumMember(Value = "HUF")] HUF,
    [EnumMember(Value = "IDR")] IDR,
    [EnumMember(Value = "INR")] INR,
    [EnumMember(Value = "JPY")] JPY,
    [EnumMember(Value = "KRW")] KRW,
    [EnumMember(Value = "MXN")] MXN,
    [EnumMember(Value = "MYR")] MYR,
    [EnumMember(Value = "NOK")] NOK,
    [EnumMember(Value = "NZD")] NZD,
    [EnumMember(Value = "PHP")] PHP,
    [EnumMember(Value = "PLN")] PLN,
    [EnumMember(Value = "RUB")] RUB,
    [EnumMember(Value = "SEK")] SEK,
    [EnumMember(Value = "SGD")] SGD,
    [EnumMember(Value = "THB")] THB,
    [EnumMember(Value = "TRY")] TRY,
    [EnumMember(Value = "USD")] USD,
    [EnumMember(Value = "ZAR")] ZAR
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
