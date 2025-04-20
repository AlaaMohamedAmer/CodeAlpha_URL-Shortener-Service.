using Microsoft.EntityFrameworkCore;
using URL_Shortener_Service.Domain_Layer;

namespace URL_Shortener_Service.Infrastructure_Layer
{
	public class UrlShortenerDbContext:DbContext
	{
        public UrlShortenerDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<URLMapping> UrlMappings => Set<URLMapping>();
    }
}
