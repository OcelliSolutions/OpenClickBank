using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ProductApprovalStatus
{
    [JsonPropertyName("ticket_id")]
    public int? TicketId { get; set; }
    public string? Status { get; set; }
    [JsonPropertyName("last_action_performed_by")]
    public Role? LastActionPerformedBy { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
