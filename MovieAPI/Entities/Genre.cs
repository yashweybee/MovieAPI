using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
    public class Genre
    {

        public int Id { get; set; }

        //[Required(ErrorMessage = "The field with name {0} is required")]
        //[FirstLetterUpperCase]

        [Required]
        [StringLength(40)]
        [FirstLetterUpperCase]
        public string Name { get; set; }



        //[Range(18, 30)]
        //public int Age { get; set; }

        //[CreditCard]
        //public string CreditCard { get; set; }

        //[Url]
        //public string Url { get; set; }


    }
}
