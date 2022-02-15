namespace ResponseService.Controllers;

using Microsoft.AspNetCore.Mvc;
[Route("api/[Controller]")]
[ApiController]
public class Response : ControllerBase
{

    [Route("{id:int}")]
    [HttpGet]
    public ActionResult GetResponse(int id)
    {
        Random ran = new();
        var ranInteger = ran.Next(1, 101);
        if (ranInteger >= id)
        {
            Console.WriteLine("--> Failed - Genrate a HTTP 500");
            return NotFound();
        }
        Console.WriteLine("--> Success - Genrate a HTTP 200");
        return Ok();
    }
}