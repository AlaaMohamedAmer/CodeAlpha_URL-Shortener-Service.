using Microsoft.EntityFrameworkCore;
using URL_Shortener_Service.Domain_Layer;

namespace URL_Shortener_Service.Infrastructure_Layer
{
	public class UrlMappingRepository : IURLMappingRepository
	{
		private readonly UrlShortenerDbContext _context;
        public UrlMappingRepository(UrlShortenerDbContext context)
        {
            _context = context;
        }
        public async Task<URLMapping> AddAsync(URLMapping urlMapping)
		{
			_context.UrlMappings.Add(urlMapping);
			await _context.SaveChangesAsync();
			return urlMapping;
		}

		public async Task<URLMapping?> GetByShortCodeAsync(string shortCode)
		{
			return	await _context.UrlMappings.FirstOrDefaultAsync(a => a.ShortCode == shortCode);
		}
	}
}
