using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ChattingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
