using System.ComponentModel.DataAnnotations;
using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class TicketComments
{
    public int? CommentId { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string? Comment { get; set; }
    [EnumDataType(typeof(TicketActionType))]
    public string? Action { get; set; }
    [EnumDataType(typeof(Role))]
    public string? CommentRole { get; set; }
}