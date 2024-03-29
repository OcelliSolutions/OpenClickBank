﻿using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TicketData
{
    public int? TicketId { get; set; }
    public string? Receipt { get; set; }
    public TicketStatus? Status { get; set; }
    public TicketType? Type { get; set; }
    public TicketCommentData[]? Comments { get; set; }
    public DateTimeOffset? OpenedDate { get; set; }
    public DateTimeOffset? ClosedDate { get; set; }
    public string? Description { get; set; }
    public RefundType? RefundType { get; set; }
    public decimal? RefundAmount { get; set; }
    public string? CustomerFirstName { get; set; }
    public string? CustomerLastName { get; set; }
    public string? Email { get; set; }
    public string? EmailAtOrderTime { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Locale { get; set; }
    public string? Note { get; set; }
    public string? ProductItemNo { get; set; }
    public DateTimeOffset? UpdateTime { get; set; }
    public TicketSource? Source { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
