using System.ComponentModel.DataAnnotations;

namespace lison7.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên thể loại")]
        public string CategoryName { get; set; } = string.Empty;

       
        public virtual ICollection<Book>? Books { get; set; }
    }
}