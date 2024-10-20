using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApplication.Controllers {
    public class LoginController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
