using Microsoft.EntityFrameworkCore;
using WebApiDemo0722.Server.EntityModel;
using WebApiDemo0722.Server.Interfaces;

namespace WebApiDemo0722.Server.Contexts
{
    public class WebApiDemo0722Context : DbContext, IWebApiDemo0722Context
    {
        public DbSet<Book> Books {get; set; } = null!;

        public WebApiDemo0722Context(DbContextOptions<WebApiDemo0722Context> Options)
                   : base(Options)
        { }
    }
}
