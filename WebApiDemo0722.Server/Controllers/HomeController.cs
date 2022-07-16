using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiDemo0722.Server.Interfaces;
using WebApiDemo0722.Server.Models;

namespace WebApiDemo0722.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWebApiDemo0722Context db;
        private readonly AppSettings settings;

        public HomeController(IWebApiDemo0722Context db, IOptions<AppSettings> settings)
        {
            this.db = db;
            this.settings = settings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = db.Books.ToList();
            return Ok(data);
        }
    }
}
