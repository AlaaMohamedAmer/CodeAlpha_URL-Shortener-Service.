
using URL_Shortener_Service.Domain_Layer;

namespace URL_Shortener_Service.Application_Layer
{
	public class UrlShortenerService : IUrlShortenerService
	{
		public readonly IURLMappingRepository _mapping;
        public UrlShortenerService(IURLMappingRepository mapping)
        {
            _mapping = mapping;
        }
        public async Task<string> GetOriginalUrl(string shortCode)
		{
			var mapping = await _mapping.GetByShortCodeAsync(shortCode);
			return mapping?.OriginalCode;
		}

		public async Task<ShortenUrlResponse> ShortenUrlAsync(ShortenUrlRequest request, string baseurl)
		{
			var shortCode = Guid.NewGuid().ToString("N")[..6];
			var entity = new URLMapping
			{
				OriginalCode = request.OriginalUrl,
				ShortCode = shortCode,
			};
			await _mapping.AddAsync(entity);

			return new ShortenUrlResponse { ShortenUrl = $"{baseurl}/r/{shortCode}" };
		}
	}
}
