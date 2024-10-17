using AssignmentWebApplication.Model;
using AssignmentWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApplication.Controllers {
    [Route("Code")]
    public class CodeController : Controller {
        private readonly DataContext context;

        public CodeController(DataContext context) {
            this.context = context;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost("RunCsCode")]
        public async Task<IActionResult> RunCsCode([FromBody] AssignmentSubmission submission) {

            var logger = HttpContext.RequestServices.GetService<ILogger<CodeController>>();

            if (submission == null) {
                logger.LogWarning("Received null submission.");
                return BadRequest("Invalid submission data.");
            }

            // Log the submission content
            // logger.LogInformation("Received submission: {@Submission}", submission);

            string content = submission.Content; // Access the content sent from JavaScript

            Runner runner = new Runner();

            var output = runner.RunCsCode(content);

            logger.LogInformation(output.ToString());

            return Json(new {
                success = true,
                message = "Submission received successfully.",
                receivedContent = content,
                assignmentId = submission.AssignmentId,
                studentId = submission.StudentId,
                isSubmitted = submission.IsSubmitted
            });
            // return Json(new { success = true });
        }

    }
}
