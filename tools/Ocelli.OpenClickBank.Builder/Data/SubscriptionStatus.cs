using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum SubscriptionStatus
{
    [EnumMember(Value = "ACTIVE")] ACTIVE,
    [EnumMember(Value = "COMPLETED")] COMPLETED,
    [EnumMember(Value = "CANCELED")] CANCELED,
    [EnumMember(Value = "RETRY_PAYMENT")] RETRY_PAYMENT,
    [EnumMember(Value = "REQUEST_NEW_CARD")] REQUEST_NEW_CARD
}