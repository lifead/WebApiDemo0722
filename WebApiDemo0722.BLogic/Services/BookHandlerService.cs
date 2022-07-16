using WebApiDemo0722.BLogic.EntityModel;
using WebApiDemo0722.BLogic.Interfaces;
using WebApiDemo0722.BLogic.Mappers;
using WebApiDemo0722.Common.Interfaces;
using WebApiDemo0722.Common.ModelsDTO;

namespace WebApiDemo0722.BLogic.Services
{
    public class BookHandlerService : IBookHandler
    {
        private readonly IWebApiDemo0722Context db;

        public BookHandlerService(IWebApiDemo0722Context db)
        {
            this.db = db;
        }

        public Task<List<BookDTO>> GetBooks()
        {
            var books = db.Books.Select(x => x.ToDto()).ToList();
            return Task.FromResult(books);
        }

        public Task<int> CreateBook(BookDTO bookDto)
        {
            Book book = bookDto.FromDto();
            db.Books.Add(book);
            db.SaveChanges();
            var result = db.Books.FirstOrDefault(x => x.Id == bookDto.Id);
            return Task.FromResult(result.Id);
        }
    }
}
