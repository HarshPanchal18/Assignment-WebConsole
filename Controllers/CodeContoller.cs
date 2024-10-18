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

            string sourceCode = submission.Content; // Access the content sent from JavaScript

            Runner runner = new Runner();

            string output = "";

            switch (submission.Language) {
                case "javascript":
                    output = runner.RunJsProgram(sourceCode);
                    break;

                case "python":
                    output = runner.RunPythonProgram(sourceCode);
                    break;

                case "java":
                    output = runner.RunJavaProgram(sourceCode);
                    break;

                case "c":
                    output = runner.RunCprogram(sourceCode);
                    break;

                case "cpp":
                    output = runner.RunCppProgram(sourceCode);
                    break;

                case "csharp":
                    output = runner.RunCsCode(sourceCode);
                    break;

            }

            return Json(new {
                success = true,
                message = "Submission received successfully.",
                receivedContent = sourceCode,
                submissionOutput = output,
                language = submission.Language,
                assignmentId = submission.AssignmentId,
                studentId = submission.StudentId,
                isSubmitted = submission.IsSubmitted
            });
        }

    }
}
