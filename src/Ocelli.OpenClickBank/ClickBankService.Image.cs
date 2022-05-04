namespace Ocelli.OpenClickBank;

public partial class ClickBankService : IImageClient
{
    public Task<ImageListResult> GetImagesAsync(string site, ImageType? type = null, bool? approvedOnly = null,
        int? page = 1, CancellationToken cancellationToken = default) =>
        Images.GetImagesAsync(site, type, approvedOnly, page, cancellationToken);
}