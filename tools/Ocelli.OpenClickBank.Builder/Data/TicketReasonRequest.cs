using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TicketReasonRequest
{
    [EnumMember(Value = "ticket.type.cancel.1")] TICKET_TYPE_CANCEL_1,
    [EnumMember(Value = "ticket.type.cancel.2")] TICKET_TYPE_CANCEL_2,
    [EnumMember(Value = "ticket.type.cancel.3")] TICKET_TYPE_CANCEL_3,
    [EnumMember(Value = "ticket.type.cancel.4")] TICKET_TYPE_CANCEL_4,
    [EnumMember(Value = "ticket.type.cancel.5")] TICKET_TYPE_CANCEL_5,
    [EnumMember(Value = "ticket.type.cancel.6")] TICKET_TYPE_CANCEL_6,
    [EnumMember(Value = "ticket.type.cancel.7")] TICKET_TYPE_CANCEL_7,
    [EnumMember(Value = "ticket.type.cancel.not.mobile")] TICKET_TYPE_CANCEL_NOT_MOBILE,
    [EnumMember(Value = "ticket.type.refund.1")] TICKET_TYPE_REFUND_1,
    [EnumMember(Value = "ticket.type.refund.2")] TICKET_TYPE_REFUND_2,
    [EnumMember(Value = "ticket.type.refund.3")] TICKET_TYPE_REFUND_3,
    [EnumMember(Value = "ticket.type.refund.4")] TICKET_TYPE_REFUND_4,
    [EnumMember(Value = "ticket.type.refund.5")] TICKET_TYPE_REFUND_5,
    [EnumMember(Value = "ticket.type.refund.6")] TICKET_TYPE_REFUND_6,
    [EnumMember(Value = "ticket.type.refund.7")] TICKET_TYPE_REFUND_7,
    [EnumMember(Value = "ticket.type.refund.8")] TICKET_TYPE_REFUND_8,
    [EnumMember(Value = "ticket.type.refund.returned")] TICKET_TYPE_REFUND_RETURNED,
    [EnumMember(Value = "ticket.type.refund.not.mobile")] TICKET_TYPE_REFUND_NOT_MOBILE,
    [EnumMember(Value = "ticket.type.tech_support.1")] TICKET_TYPE_TECH_SUPPORT_1,
    [EnumMember(Value = "ticket.type.tech_support.2")] TICKET_TYPE_TECH_SUPPORT_2,
    [EnumMember(Value = "ticket.type.tech_support.3")] TICKET_TYPE_TECH_SUPPORT_3,
    [EnumMember(Value = "ticket.type.tech_support.4")] TICKET_TYPE_TECH_SUPPORT_4,
    [EnumMember(Value = "ticket.type.tech_support.9")] TICKET_TYPE_TECH_SUPPORT_9,
    [EnumMember(Value = "ticket.type.tech_support.10")] TICKET_TYPE_TECH_SUPPORT_10
}
