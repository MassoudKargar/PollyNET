namespace ResponseService.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class Response : ControllerBase {
    [Route("{id:int}")]
    [HttpGet]
    public IActionResult GetAResponse(int id) {
        Random ran = new();
        var ranInteger = ran.Next(1,101);
        if (ranInteger >= id) {
            Console.WriteLine("--> Failed - Genrate a HTTP 500");
            return StatusCode(StatusCode.InternalServerError);
        }
            Console.WriteLine("--> Failed - Genrate a HTTP 500");
        return OK();
    }
}