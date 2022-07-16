using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiDemo0722.Common.Interfaces;
using WebApiDemo0722.Common.ModelsDTO;
using WebApiDemo0722.Server.Models;

namespace WebApiDemo0722.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppSettings settings;
        private readonly IBookHandler bookHandler;

        public HomeController(IBookHandler bookHandler, IOptions<AppSettings> settings)
        {
            this.settings = settings.Value;
            this.bookHandler = bookHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await bookHandler.GetBooks();
            return Ok(data);
        }

        [HttpPost]
        public async Task< int> Post(BookDTO bookDTO)
        {
            var id = await bookHandler.CreateBook(bookDTO);
            return id;
        }
    }
}
