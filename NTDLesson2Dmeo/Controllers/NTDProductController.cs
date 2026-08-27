using Microsoft.AspNetCore.Mvc;
using NTDLesson2Dmeo.Models;

namespace NTDLesson2Dmeo.Controllers
{
    public class NTDProductController : Controller
    {
        public IActionResult Index()
        {
            //đưa dữ liệu ra view
            ViewBag.name = "Tùng Dương";
            ViewData["adress"] = "Fit NTU";
            TempData["UNI"] = "Trường Đại Học Nguyễn Trãi";

            return View();
        }

        //chi tiết sản phẩm 
        public IActionResult GetProduct()
        {
            //Mock data
            NTDProduct nTDProduct = new NTDProduct()
            {
                ProductId = "P001",
                ProductName = "laptop ASUS",
                YearRelease = 2021,
                Price = 15000000,
            };
            ViewData["productVD"]= nTDProduct;
            ViewBag.productVB = nTDProduct;

            return View();
        }
    }
}
