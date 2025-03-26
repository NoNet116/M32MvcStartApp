using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Repositories;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {

        private readonly ILogRepository _repo;
        public LogsController(ILogRepository repo)
        {
            _repo = repo;
        }
               
        public async Task<ActionResult> IndexAsync()
        {
            var authors = await _repo.GetRequests();
            return View(authors.OrderByDescending(x => x.Date));
        }


    }
}
