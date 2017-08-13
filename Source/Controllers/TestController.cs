using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {

        [HttpGet]
        public string Get()
        {
            return "Hello world";
        }
    }
}