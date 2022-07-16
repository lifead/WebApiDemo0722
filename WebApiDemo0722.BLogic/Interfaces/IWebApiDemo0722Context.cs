using Microsoft.EntityFrameworkCore;
using WebApiDemo0722.BLogic.EntityModel;

namespace WebApiDemo0722.BLogic.Interfaces
{
    public interface IWebApiDemo0722Context
    {
        public DbSet<Book> Books { get; set; }
        public int SaveChanges();
    }
}
