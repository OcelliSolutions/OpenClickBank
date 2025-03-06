using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Ocelli.OpenClickBank;
internal class NotificationService : INotificationService
{
    public Notification DecryptNotification(string cipherText, string secretKey, string initVector)
    {
        var decryptedString = DecryptNotificationJson(cipherText, secretKey, initVector);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new EnumConverter<NotificationTransactionType>());
        options.Converters.Add(new EnumConverter<NotificationRole>());
        options.Converters.Add(new EnumConverter<PaymentMethod>());
        options.Converters.Add(new EnumConverter<LineItemType>());
        options.Converters.Add(new DateTimeOffsetConverter());
        var result = JsonSerializer.Deserialize<Notification>(decryptedString, options);
        return result ?? new Notification();
    }

    public string DecryptNotificationJson(string cipherText, string secretKey, string initVector)
    {
        var inputBytes = Encoding.UTF8.GetBytes(secretKey);

        var sha1 = SHA1.Create();
        var key = sha1.ComputeHash(inputBytes);

        var hex = new StringBuilder(key.Length * 2);
        foreach (var b in key)
            hex.Append($"{b:x2}");

        var secondPhaseKey = hex.ToString()[..32];

        var asciiEncoding = new ASCIIEncoding();

        var keyBytes = asciiEncoding.GetBytes(secondPhaseKey);
        var iv = Convert.FromBase64String(initVector);

        var aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using Stream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText));
        using CryptoStream cryptoStream =
            new(memoryStream, aes.CreateDecryptor(keyBytes, iv), CryptoStreamMode.Read);
        var decryptedString = new StreamReader(cryptoStream).ReadToEnd();
        return decryptedString;
    }
}
