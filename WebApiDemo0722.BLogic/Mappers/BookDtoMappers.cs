using WebApiDemo0722.BLogic.EntityModel;
using WebApiDemo0722.Common.ModelsDTO;

namespace WebApiDemo0722.BLogic.Mappers
{
    public static class BookDtoMappers
    {
        public static BookDTO ToDto(this Book obj)
        {
            if (obj == null) return null;
            return new BookDTO
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static Book FromDto(this BookDTO obj)
        {
            if (obj == null) return null;
            return new Book
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

    }
}
