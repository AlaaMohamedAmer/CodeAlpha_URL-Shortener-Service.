namespace URL_Shortener_Service.Application_Layer
{
	public interface IUrlShortenerService
	{
		public Task<ShortenUrlResponse> ShortenUrlAsync(ShortenUrlRequest request, string baseurl);
		Task<string> GetOriginalUrl(string shortCode);
	}
}
