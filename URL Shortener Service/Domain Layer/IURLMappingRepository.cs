namespace URL_Shortener_Service.Domain_Layer
{
	public interface IURLMappingRepository
	{
		Task<URLMapping> AddAsync(URLMapping urlMapping);

		Task<URLMapping?> GetByShortCodeAsync(string shortCode);
	}
}
