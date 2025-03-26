using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;

namespace MvcStartApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult ContactForm(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Обработка отправки данных (например, отправка письма)
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
