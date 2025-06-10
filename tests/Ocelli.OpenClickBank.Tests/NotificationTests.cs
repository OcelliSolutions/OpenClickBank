using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("NotificationTests")]
public class NotificationTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper = new(testOutputHelper);
    private const string Encrypted = "MBEoe/2rchEe6sWyCfHHGkcjdVc1UzdciFfivskjXp67Wg+vVnrSFpVpw+UjrNlCrbZ2ThZZjUyzemuOoPjIUGICdEtNQtA7h2E2J3jR++p8NyQBYjjXsMaTEe9i2Ka5jehEE5IjTZzJqRE1lt0eSXcZ31ZLyaWuvMeviAGNGJtxodhmovBIByzPinsRdsqCs9Z4Li+0tGQ2pOmZQ0XfM5Yrh3Z7e1X9E8FOeK+36Obmu5ntj3AjvDqdLxATLjQMvf+A29mlOgKOEDm5k5tleVRIgm8QXLdv6c+4HdkHOVfEv0UbJimcrhznTpCp3WIGETD8NGWShx/qt4nA6fGNlmbpl8wcDJE69416ZVjGvQLPjYy/JM+AoNWOFF+R8BY+r9JSAQyFeXGai6nJDCHO0Gk3u7ERyEc5txqMajT9zuqcqWgEF9EOLjVRekZhZkN0VuqviZjXgnktJkjct+obJ+a/RKFI7invriI6O0jzAOdc9hioUcT9YI2U9JRVX7CmddIZqtObkyG3pacOQV4YcdBTd02TZmoNZmqZVkqsCbRshC18cSSLEL764DORri5DJVvIzmJrUudKDivO4MUHJN/deX4mzlTQ8Rn9iv75IR/g72MehQHb17h2JUPxs//YDMoOBR+PMz36kt0F8XDCYnWbCZvOQLdf0AZmrQscOEDf/HfL42+Xd3Rzbuv7MLJSjhRIAJy2ct48PIaQix25SwjImvgPmvGe+jeJS8wn6SoCeZXj5Oz7qbbYEmPOXZDnMf/s4E/nIhGLpK1y6CoQEwoyTFSAB6Jt+dwvThrLKNgQRhZD23js6CrUnAwR2Tb+SlGZulXcSV23/7AG2xlI18KL9cK5+PXeYnpeTOduqUvzZm4SsAHz3ajYohc4oKF/welOsr8FzwEiJeCkMjEsm7c2HP+iQcBKBtYgx6KBc5HJ7IGMcjKQMpIO3N5daYZK2P9agaMJA0HHPx12lkF9VI4GgOe0Q2GYtJhXtshL/g0+z5njhILS1V30Wk4eCqds4oq+r4Y6aC+lomp08iPcwAVs6o4kFY04QmXmFKENfCzCIQvkfCV7CsOQYyhFOrlA";
    private const string InitVector = "QTYyMzA3QjczMTEyRkI3QQ==";
    private const string SecretKey = "01GA50AY4BYGZKG6";

    private SharedFixture Fixture { get; } = sharedFixture;

    [Fact]
    public void DecryptNotification_CanDecrypt()
    {
        var notification = Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, SecretKey, InitVector);
        Assert.NotNull(notification);
        _additionalPropertiesHelper.CheckAdditionalProperties(notification,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        if (notification == null) return;

        Assert.Equal(DateTimeOffset.Parse("2022-08-10 16:20:15 -07:00"), notification.TransactionTime);
        Assert.Equal("********", notification.Receipt);
        Assert.Equal(NotificationTransactionType.TEST, notification.TransactionType);
        Assert.Equal("ketoboost1", notification.Vendor);
        Assert.Equal(NotificationRole.VENDOR, notification.Role);
        Assert.Equal((decimal)1.0, notification.TotalAccountAmount);
        Assert.Equal("VISA", notification.PaymentMethod);
        Assert.Equal((decimal)1.0, notification.TotalOrderAmount);
        Assert.Equal((decimal)0.0, notification.TotalTaxAmount);
        Assert.Equal((decimal)0.0, notification.TotalShippingAmount);
        Assert.Equal("USD", notification.Currency);
        Assert.Equal("A passed in title", notification.LineItems.First().ProductTitle);
        Assert.Equal("Test", notification.Customer.Shipping?.FirstName);
        Assert.Equal("Test", notification.Customer.Billing?.FirstName);
        Assert.Equal((decimal)7.0, notification.Version);
        Assert.Equal(1, notification.AttemptCount);
    }

    [Fact]
    public void DecryptNotification_ShortSecret_ShouldFail()
    {
        const string secretKey = "01GA50";

        Assert.Throws<CryptographicException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, secretKey, InitVector));
    }

    [Fact]
    public void DecryptNotification_LongSecret_ShouldFail()
    {
        const string secretKey = "01GA5001GA5001GA50";

        Assert.Throws<CryptographicException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, secretKey, InitVector));
    }

    [Fact]
    public void DecryptNotification_EmptySecret_ShouldFail()
    {
        var secretKey = string.Empty;

        Assert.Throws<CryptographicException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, secretKey, InitVector));
    }

    [Fact]
    public void DecryptNotification_InvalidSecret_ShouldFail()
    {
        const string secretKey = "01GA50AY4BYGZKG0";

        Assert.Throws<CryptographicException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, secretKey, InitVector));
    }
    [Fact]
    public void DecryptNotification_InvalidInitVector_ShouldFail()
    {
        //This is still a valid base64 string
        const string initVector = "QTYyMzA3QjczMTEyRkI3Qgo=";

        Assert.Throws<CryptographicException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, SecretKey, initVector));
    }
    [Fact]
    public void DecryptNotification_InvalidBase64InitVector_ShouldFail()
    {
        //This is still a valid base64 string
        const string initVector = "QTYyMzA3QjczMTEyRkI3QQ=";

        Assert.Throws<FormatException>(() =>
            Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(Encrypted, SecretKey, initVector));
    }

    [Fact]
    public void DecryptSensitiveDataFromFile()
    {
        // Read test data from the JSON file
        string json = File.ReadAllText("ins.json");
        var testData = JsonSerializer.Deserialize<SensitiveTestData[]>(json);

        foreach (var data in testData)
        {
            // Attempt to decrypt the sensitive data
            try
            {
                var notification = Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(data.Notification, data.Secret, data.Iv);
                // You can perform further checks/assertions here as needed
                Assert.NotNull(notification);
            }
            catch (Exception ex)
            {
                // Handle decryption errors, e.g., log the error or fail the test
                Assert.Fail($"Decryption failed for notification '{data.Notification}': {ex.Message}");
            }
        }
    }
    public class SensitiveTestData
    {
        [JsonPropertyName("notification")]
        public string Notification { get; set; } = null!;
        [JsonPropertyName("iv")]
        public string Iv { get; set; } = null!;

        [JsonPropertyName("secret")]
        public string Secret { get; set; } = null!;
    }
}
