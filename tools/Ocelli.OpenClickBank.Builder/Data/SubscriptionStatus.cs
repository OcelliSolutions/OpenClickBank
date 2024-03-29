﻿using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum SubscriptionStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "ACTIVE")] ACTIVE,
    [EnumMember(Value = "COMPLETED")] COMPLETED,
    [EnumMember(Value = "CANCELED")] CANCELED,
    [EnumMember(Value = "RETRY_PAYMENT")] RETRY_PAYMENT,
    [EnumMember(Value = "REQUEST_NEW_CARD")] REQUEST_NEW_CARD
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
