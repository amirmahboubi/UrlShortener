using Microsoft.AspNetCore.Mvc;
using System.Net;
using UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared;
using UrlShortener.Core.Application.Interfaces.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string shortUrl)
        {
            ResponseBase<string> response = await _urlShortenerService.GetOriginalUrl(shortUrl);
            return StatusCode((int)(response?.Header?.StatusCode ?? HttpStatusCode.InternalServerError), response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string originalUrl)
        {
            ResponseBase<string> response = await _urlShortenerService.GenerateShortUrl(originalUrl);
            return StatusCode((int)(response?.Header?.StatusCode ?? HttpStatusCode.InternalServerError), response);
        }
    }
}
