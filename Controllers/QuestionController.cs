using AssignmentWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApplication.Controllers {
    public class QuestionController : Controller {
        private readonly DataContext context;

        public QuestionController(DataContext context) {
            this.context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
