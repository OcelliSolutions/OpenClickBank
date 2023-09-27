using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TicketCommentData
{
    public int? CommentId { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string? Comment { get; set; }
    public TicketActionType? Action { get; set; }
    public Role? CommentRole { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
