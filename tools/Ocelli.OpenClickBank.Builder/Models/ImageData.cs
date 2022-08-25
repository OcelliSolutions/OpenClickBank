using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ImageData
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public ImageType? Type { get; set; }
    public bool Approved { get; set; }
}