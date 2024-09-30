using AssignmentWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssignmentWebApplication.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : Controller {
        private readonly ILogger<CreateController> _logger;

        public CreateController(ILogger<CreateController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }
        public IActionResult Question() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
