using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
namespace ResponseService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class Response : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {

        HttpClient client = new();
        var response = await client.GetAsync("https://localhost:7136/api/Response/25");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("ResponseService returned SUCCESS");
            return Ok();
        }

        Console.WriteLine("ResponseService returned FAILURE");
        return StatusCode(StatusCodes.Status500InternalServerError);

    }
}