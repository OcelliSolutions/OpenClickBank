using System;
using System.Text.Json;

namespace Ocelli.OpenClickBankTests;

[Collection("Shared collection")]
public class NotificationTests : IClassFixture<SharedFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public NotificationTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    public void DecryptNotification_CanDecrypt()
    {
        const string encrypted = "MBEoe/2rchEe6sWyCfHHGkcjdVc1UzdciFfivskjXp67Wg+vVnrSFpVpw+UjrNlCrbZ2ThZZjUyzemuOoPjIUGICdEtNQtA7h2E2J3jR++p8NyQBYjjXsMaTEe9i2Ka5jehEE5IjTZzJqRE1lt0eSXcZ31ZLyaWuvMeviAGNGJtxodhmovBIByzPinsRdsqCs9Z4Li+0tGQ2pOmZQ0XfM5Yrh3Z7e1X9E8FOeK+36Obmu5ntj3AjvDqdLxATLjQMvf+A29mlOgKOEDm5k5tleVRIgm8QXLdv6c+4HdkHOVfEv0UbJimcrhznTpCp3WIGETD8NGWShx/qt4nA6fGNlmbpl8wcDJE69416ZVjGvQLPjYy/JM+AoNWOFF+R8BY+r9JSAQyFeXGai6nJDCHO0Gk3u7ERyEc5txqMajT9zuqcqWgEF9EOLjVRekZhZkN0VuqviZjXgnktJkjct+obJ+a/RKFI7invriI6O0jzAOdc9hioUcT9YI2U9JRVX7CmddIZqtObkyG3pacOQV4YcdBTd02TZmoNZmqZVkqsCbRshC18cSSLEL764DORri5DJVvIzmJrUudKDivO4MUHJN/deX4mzlTQ8Rn9iv75IR/g72MehQHb17h2JUPxs//YDMoOBR+PMz36kt0F8XDCYnWbCZvOQLdf0AZmrQscOEDf/HfL42+Xd3Rzbuv7MLJSjhRIAJy2ct48PIaQix25SwjImvgPmvGe+jeJS8wn6SoCeZXj5Oz7qbbYEmPOXZDnMf/s4E/nIhGLpK1y6CoQEwoyTFSAB6Jt+dwvThrLKNgQRhZD23js6CrUnAwR2Tb+SlGZulXcSV23/7AG2xlI18KL9cK5+PXeYnpeTOduqUvzZm4SsAHz3ajYohc4oKF/welOsr8FzwEiJeCkMjEsm7c2HP+iQcBKBtYgx6KBc5HJ7IGMcjKQMpIO3N5daYZK2P9agaMJA0HHPx12lkF9VI4GgOe0Q2GYtJhXtshL/g0+z5njhILS1V30Wk4eCqds4oq+r4Y6aC+lomp08iPcwAVs6o4kFY04QmXmFKENfCzCIQvkfCV7CsOQYyhFOrlA";
        const string iv = "QTYyMzA3QjczMTEyRkI3QQ==";
        const string secret = "01GA50AY4BYGZKG6";

        var notification = Fixture.ApiKey.ClickBankService.Notifications.DecryptNotification(encrypted, secret, iv);
        Assert.NotNull(notification);
        if (notification == null) return;

        Assert.Equal(DateTimeOffset.Parse("2022-08-10 16:20:15 -07:00"), notification.TransactionTime);
        Assert.Equal("********", notification.Receipt);
        Assert.Equal(TransactionType.TEST, notification.TransactionType);
        Assert.Equal("ketoboost1", notification.Vendor);
        Assert.Equal(NotificationRole.VENDOR, notification.Role);
        Assert.Equal((decimal)1.0, notification.TotalAccountAmount);
        Assert.Equal(PaymentMethod.VISA, notification.PaymentMethod);
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
}
