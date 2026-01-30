using LinksUpdater.Logic;
using Microsoft.AspNetCore.Mvc;

namespace LinksUpdater.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinkController : ControllerBase
{
    private readonly LinkService _linkService;
    
    public LinkController(LinkService linkService)
    {
        _linkService = linkService;
    }
    public record ShortenRequest(string Url);

    [HttpPost("shorten")]
    public async Task<IActionResult> Shorten([FromBody] ShortenRequest request)
    {
        var result = await _linkService.ShortenUrlAsync(request.Url);
        
        if (result.StartsWith("Error")) 
            return BadRequest(result);

        var host = Request.Host.Value;
        var scheme = Request.Scheme;
        var fullUrl = $"{scheme}://{host}/api/link/{result}";

        return Ok(new { ShortCode = result, FullUrl = fullUrl });
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectTo(string code) 
    {
        var url = await _linkService.GetUrlAsync(code);
        
        if (url == null) 
            return NotFound("Посилання не знайдено або воно застаріло");
        
        return Redirect(url);
    }
}