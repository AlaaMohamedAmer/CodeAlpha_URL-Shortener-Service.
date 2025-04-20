using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener_Service.Application_Layer;

namespace URL_Shortener_Service.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UrlController : ControllerBase
	{
		private readonly IUrlShortenerService _service;

		public UrlController(IUrlShortenerService service)
		{
			_service = service;
		}

		[HttpPost("shorten")]
		public async Task<IActionResult> Shorten([FromBody] ShortenUrlRequest request)
		{
			var baseUrl = $"{Request.Scheme}://{Request.Host}";

			var result = await _service.ShortenUrlAsync(request, baseUrl);
			return Ok(result);
		}
	}
}
