using System.ComponentModel.DataAnnotations;

namespace lison5.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên tác giả")]
        public string AuthorName { get; set; } = string.Empty;

        [Display(Name = "Tiểu sử")]
        public string? Bio { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}