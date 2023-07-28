using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
public class ShipnoticeController : ShipnoticeControllerBase
{
    public override Task CreateShipnotice(CreateShipnoticeRequest request, string receipt, string date, string carrier,
        string? tracking = null, string? comments = null, string? item = null, string? fillOrder = null) =>
        throw new NotImplementedException();

    public override Task GetShipnotice(string receipt) => throw new NotImplementedException();
}