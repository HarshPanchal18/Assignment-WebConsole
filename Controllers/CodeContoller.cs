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

        [HttpPost("RunCode")]
        public IActionResult RunCode([FromBody] AssignmentSubmission submission) {

            ILogger<CodeController> logger = HttpContext.RequestServices.GetService<ILogger<CodeController>>()!;

            if (submission == null) {
                logger.LogWarning("Received null submission.");
                return BadRequest("Invalid submission data.");
            }

            // Log the submission content
            logger.LogInformation("Received submission: {@Submission}", submission);

            string content = submission.Content; // Access the content sent from JavaScript

            Runner runner = new Runner();

            string output = "";

            switch (submission.Language) {
                case "javascript":
                    output = runner.RunJsProgram(content);
                    break;

                case "python":
                    output = runner.RunPythonProgram(content);
                    break;

                case "java":
                    output = runner.RunJavaProgram(content);
                    break;

                case "cpp":
                    output = runner.RunCppProgram(content);
                    break;

                case "csharp":
                    output = runner.RunCsCode(content);
                    break;

            }

            return Json(new {
                success = true,
                message = "Submission received successfully.",
                receivedContent = content,
                submissionOutput = output,
                language = submission.Language,
                assignmentId = submission.AssignmentId,
                studentId = submission.StudentId,
                isSubmitted = submission.IsSubmitted
            });
        }

    }
}
