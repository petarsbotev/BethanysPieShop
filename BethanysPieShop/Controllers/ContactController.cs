using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendEmail()
        {
            // Logic to send email would go here
            // For now, just redirect to the index view
            return RedirectToAction("Index");
        }
    }
}
