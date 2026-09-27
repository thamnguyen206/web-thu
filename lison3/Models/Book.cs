using System.ComponentModel.DataAnnotations;

namespace lison3.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        [Display(Name = "Giá sách")]
        public decimal Price { get; set; }
    }
}