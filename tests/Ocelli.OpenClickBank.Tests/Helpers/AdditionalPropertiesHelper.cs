using System.Text.Json;

namespace Ocelli.OpenClickBank.Tests.Helpers;

public class AdditionalPropertiesHelper(ITestOutputHelper testOutputHelper)
{
    public void CheckAdditionalProperties(object? obj, string path)
    {
        if (obj == null) return;
        var objType = obj.GetType();
        var properties = objType.GetProperties();
        foreach (var property in properties)
        {
            var currentPath = $@"{path}.{property.Name}";
            var propValue = property.GetValue(obj, null);
            if (property.PropertyType.Assembly == objType.Assembly &&
                property.Name != nameof(AccountList.AdditionalProperties))
                //_testOutputHelper.WriteLine(currentPath);
                CheckAdditionalProperties(propValue, currentPath);
            else if (property.Name == nameof(AccountList.AdditionalProperties))
            {
                if (propValue != null && ((IDictionary<string, object>)propValue).Count == 0) continue;

                var nonNullProperties =
                    ((IDictionary<string, object?>)propValue! ?? throw new InvalidOperationException())
                    .Where(kvp => kvp.Value != null)
                    .ToList();

                if (nonNullProperties.Count == 0) continue;
                testOutputHelper.WriteLine("{0}: {1}", currentPath, JsonSerializer.Serialize(nonNullProperties));

                Assert.Empty(nonNullProperties);
            }
        }
    }
}
