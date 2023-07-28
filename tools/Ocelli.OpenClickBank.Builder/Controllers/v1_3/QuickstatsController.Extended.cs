using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
public class QuickstatsController : QuickstatsControllerBase
{
    public override Task Count(DateTime? startDate = null, DateTime? endDate = null, string? account = null) => throw new NotImplementedException();

    public override Task List(DateTime? startDate = null, DateTime? endDate = null, string? account = null, int? page = null) => throw new NotImplementedException();
    public override Task Accounts() => throw new NotImplementedException();
}