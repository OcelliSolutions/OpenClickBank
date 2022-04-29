namespace OpenClickBank;

public partial class ClickBankService : IImageClient
{
    public Task<ImageListResult> GetImagesAsync(string site, ImageType? type = null, bool? approvedOnly = null,
        CancellationToken cancellationToken = default) =>
        Images.GetImagesAsync(site, type, approvedOnly, cancellationToken);
}