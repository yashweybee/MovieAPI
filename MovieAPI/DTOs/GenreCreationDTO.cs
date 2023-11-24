using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class GenreCreationDTO
    {

        [Required]
        [StringLength(40)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
