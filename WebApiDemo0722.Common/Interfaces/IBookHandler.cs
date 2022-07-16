using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDemo0722.Common.ModelsDTO;

namespace WebApiDemo0722.Common.Interfaces
{
    public interface IBookHandler
    {
        [Get("/Home")]
        public Task<List<BookDTO>> GetBooks();

        [Post("/Home")]
        public Task<int> CreateBook(BookDTO bookDto);
    }
}
