using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using LinksUpdater.Logic;

namespace LinksUpdater.Logic;

public class LinkService
{
    private const string allSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
    private static readonly HttpClient _httpClient = new HttpClient();
    private readonly AppDbContext _context;
    
    public LinkService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<string> ShortenUrlAsync(string targetUrl)
    {
        bool isAlive = await CheckUrlAsync(targetUrl);
        if (!isAlive) return "Error: URL is not accessible";

        string newCode;
        do
        {
            newCode = GenerateCodeChars();
        } while (await _context.Links.AnyAsync(l => l.Code == newCode));
        
        var newLink = new ShortLink 
        { 
            Code = newCode, 
            OriginalUrl = targetUrl 
        };

        _context.Links.Add(newLink);
        await _context.SaveChangesAsync(); 

        return newCode;
    }
    
    public async Task<string?> GetUrlAsync(string code)
    {
        var link = await _context.Links.FirstOrDefaultAsync(l => l.Code == code);
        return link?.OriginalUrl;
    }
    
    private async Task<bool> CheckUrlAsync(string url)
    {
        try 
        {
            var request = new HttpRequestMessage(HttpMethod.Head, url);
            using var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        catch 
        {
            return false;
        }
    }
    private string GenerateCodeChars()
    {
        char[] code = new char[6];
        for (int i = 0; i < code.Length; i++)
        {
            int index = RandomNumberGenerator.GetInt32(0, allSymbols.Length);
            code[i] = allSymbols[index];
        }
        return new string(code);
    }
}
