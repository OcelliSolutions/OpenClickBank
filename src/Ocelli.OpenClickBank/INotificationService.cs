namespace Ocelli.OpenClickBank;
public interface INotificationService
{
    /// <summary>
    /// Instant Notification Service (INS) 
    /// </summary>
    /// <param name="cipherText">The `notification` property of a INS message.</param>
    /// <param name="secretKey">`The `Secret Key` used when registering the `Instant Notification URL`.</param>
    /// <param name="initVector">The `iv` property of a INS message</param>
    /// <returns></returns>
    public Notification DecryptNotification(string cipherText, string secretKey, string initVector);

    /// <summary>
    /// Instant Notification Service (INS) that does not process the JSON
    /// </summary>
    /// <param name="cipherText">The `notification` property of a INS message.</param>
    /// <param name="secretKey">`The `Secret Key` used when registering the `Instant Notification URL`.</param>
    /// <param name="initVector">The `iv` property of a INS message</param>
    /// <returns>Raw JSON of the INS message</returns>
    public string DecryptNotificationJson(string cipherText, string secretKey, string initVector);
}
