using Microsoft.EntityFrameworkCore;
using WebApiDemo0722.Server.EntityModel;

namespace WebApiDemo0722.Server.Interfaces
{
    public interface IWebApiDemo0722Context
    {
        public DbSet<Book> Books { get; set; } 
    }
}
