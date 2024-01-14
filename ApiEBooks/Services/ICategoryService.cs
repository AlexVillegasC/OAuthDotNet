using ApiEBooks.Dto;
using ApiEBooks.Models.Dto;

namespace ApiEBooks.Services
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDto> Get();
        public CategoryDto? Get(int id);

        CategoryDto Create(CategoryDto category);
        void Update(CategoryDto category);
        void Delete(int id);
    }
}
