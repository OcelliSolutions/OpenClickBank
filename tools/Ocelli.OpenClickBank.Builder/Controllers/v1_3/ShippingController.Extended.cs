using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ShippingController : ShippingControllerBase
{
    public override Task Count(string? status = null, string? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null) =>
        throw new NotImplementedException();

    public override Task List(string? status = null, string? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null, int? page = null) =>
        throw new NotImplementedException();
}