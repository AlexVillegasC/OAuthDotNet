using ApiEBooks.Dto;
using ApiEBooks.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace ApiEBooks.Dto
{
    public class BookDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public AuthorDto Author { get; set; }

        [Required]
        public CategoryDto Category { get; set; }
    }
}
