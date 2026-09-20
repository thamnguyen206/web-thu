using Microsoft.AspNetCore.Mvc;

namespace lisson2.Controllers
{
    public class ProductController : Controller
    {
        public string Detail(int? id)
        {
            if (id == null)
                return "Lỗi: Vui lòng cung cấp ID sản phẩm";

            return "Product ID = " + id;
        }

        public string Category(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "Lỗi: Vui lòng cung cấp tên category";

            return "Category = " + name;
        }
    }
}