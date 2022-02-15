
namespace ResponseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Response : ControllerBase
{
    public Response(IHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }
    private IHttpClientFactory HttpClientFactory { get; }
    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {
        // HttpClient client = new();
        var client = HttpClientFactory.CreateClient("PollyNet");
        var response = await client.GetAsync("https://localhost:7136/api/Response/25");
        // var response = await ClientPulicy.ImmutableHttpRetry.ExecuteAsync(
        //     () => client.GetAsync("https://localhost:7136/api/Response/25"));
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("ResponseService returned SUCCESS");
            return Ok();
        }
        Console.WriteLine("ResponseService returned FAILURE");
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}