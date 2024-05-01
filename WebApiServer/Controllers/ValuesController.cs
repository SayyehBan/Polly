using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{

    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        Random random = new Random();
        if (random.Next(4) != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Api Log: Exception in api server...{DateTime.Now.ToString()}");

        }

        return new string[] { "value1", "value2" };
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
