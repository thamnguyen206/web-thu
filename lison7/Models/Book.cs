using lison7.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lison7.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Tiêu đề sách không được để trống")]
        [StringLength(200)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; } = string.Empty;

        [StringLength(20)]
        public string? ISBN { get; set; }

        [Range(0, 10000000, ErrorMessage = "Giá sách phải từ 0 VNĐ")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng kho")]
        public int Quantity { get; set; }

        [Display(Name = "Năm xuất bản")]
        public int PublishYear { get; set; }

        [Display(Name = "Ảnh bìa URL")]
        public string? ImageUrl { get; set; }

                          
        [Display(Name = "Thể loại")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }
    }
}