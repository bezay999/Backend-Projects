using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Logic;
namespace PasswordGenerator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolsController : ControllerBase
{
    private readonly CesarCipher _cipher;
    private readonly CreateStrongPassword _passwordGen;

    public ToolsController(CesarCipher cipher, CreateStrongPassword passwordGen)
    {
        _cipher = cipher;
        _passwordGen = passwordGen;
    }

    [HttpGet("cipher")]
    public IActionResult Encrypt([FromQuery] string text)
    {
        _cipher.Text = text;
        var result = _cipher.Encrypt(); 
        return Ok(new { Original = text, Encrypted = result });
    }

    [HttpPost("password")] 
    public IActionResult CreatePassword([FromBody] PasswordRequest request)
    {
        var password = _passwordGen.Generate(request.Size);
        return Ok(new { Password = password });
    }
}

public record PasswordRequest(int Size);