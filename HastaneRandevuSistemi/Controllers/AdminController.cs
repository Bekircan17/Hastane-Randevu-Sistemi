using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSau.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="yetkili")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
