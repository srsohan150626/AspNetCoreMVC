

using System.ComponentModel.DataAnnotations;

namespace CoreMVCFirstApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name of your book.")]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please select your book language!")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Enter valid page number of your book.")]
        [Display(Name = "Total page of your book")]
        public int? TotalPage { get; set; }
    }
}
