using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Refit;
using WebApiDemo0722.Common.Interfaces;
using WebApiDemo0722.UI.Models;

namespace WebApiDemo0722.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly ServerData options;

        public BookController(IOptions<ServerData> options)
        {
            this.options = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            var gitHubApi = RestService.For<IBookHandler>(options.UrlBook);
            var books = await gitHubApi.GetBooks();
            return View(books);
        }
    }
}
