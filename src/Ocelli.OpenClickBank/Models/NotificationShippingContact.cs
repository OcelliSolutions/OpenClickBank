namespace Ocelli.OpenClickBank;

public class NotificationShippingContact
{
    public string FirstName { get; set; } = null!;


    public string LastName { get; set; } = null!;

    public string FullName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public NotificationAddress? Address { get; set; }
}