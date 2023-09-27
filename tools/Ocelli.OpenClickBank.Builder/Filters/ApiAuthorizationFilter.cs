using Microsoft.AspNetCore.Mvc.Filters;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Extensions;

namespace Ocelli.OpenClickBank.Builder.Filters;

/// <summary>
///     If there are ApiPermissions attributed to a controller action, create a concatenated string of all the assigned
///     permissions.
/// </summary>
public class ApiAuthorizationFilter : ActionFilterAttribute
{
    private readonly List<ApiPermission>? _apiPermissions;

    /// <inheritdoc />
    public ApiAuthorizationFilter() { }

    /// <inheritdoc />
    public ApiAuthorizationFilter(ApiPermission[] permissions)
    {
        _apiPermissions = new List<ApiPermission>();
        _apiPermissions.AddRange(permissions);
    }

    /// <summary>
    /// The display name of the permission
    /// </summary>
    public string PermissionDescription
    {
        get
        {
            if (_apiPermissions == null || !_apiPermissions.Any()) return "<i>none</i>";
            var displayNames = _apiPermissions.Select(permission => permission.GetDisplayName());
            return string.Join(" • ", displayNames);
        }
    }
}