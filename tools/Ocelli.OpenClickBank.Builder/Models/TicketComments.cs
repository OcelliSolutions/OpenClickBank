using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class TicketComments
{
    public int? CommentId { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string? Comment { get; set; }
    public TicketActionType? Action { get; set; }
    public Role? CommentRole { get; set; }
}