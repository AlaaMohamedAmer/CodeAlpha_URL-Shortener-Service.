using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener_Service.Application_Layer;

namespace URL_Shortener_Service.Controllers
{
	[ApiController]
	[Route("r/{shortCode}")]
	public class RedirectController : ControllerBase
	{
		private readonly IUrlShortenerService _service;
		public RedirectController(IUrlShortenerService service) => _service = service;

		[HttpGet]
		public async Task<IActionResult> RedirectToOriginal(string shortCode)
		{
			var url = await _service.GetOriginalUrl(shortCode);
			if (url == null) return NotFound();
			return Redirect(url);
		}
	}
}
