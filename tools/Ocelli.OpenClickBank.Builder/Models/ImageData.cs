using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ImageData
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public ImageType? Type { get; set; }
    public bool Approved { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
