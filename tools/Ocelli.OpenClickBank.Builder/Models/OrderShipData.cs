namespace Ocelli.OpenClickBank.Builder.Models;

public class OrderShipData
{
    public string? Receipt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public DateTimeOffset? TransactionTime { get; set; }
    public bool? IsTestTransaction { get; set; }
    public string? FullName { get; set; }
    public string? Vendor { get; set; }
    public VendorVariableElementArray? VendorVariables { get; set; }
    public OrderShipLineItemData[]? LineItemShipData { get; set; }
}