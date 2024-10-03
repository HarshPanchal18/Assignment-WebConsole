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

        /*[HttpGet("{code}")]
        public async Task<IActionResult> CheckTestcases(string code) {
            // Prepare test cases
            List<Testcase<int>> testCases = new List<Testcase<int>> {
                new Testcase<int>(5, (DataType.INT, "2"), (DataType.INT, "3")),
                new Testcase<int>(19, (DataType.INT, "7"), (DataType.INT, "12")),
                new Testcase<int>(-3, (DataType.INT, "-1"), (DataType.INT, "-2")),
                new Testcase<int>(0, (DataType.INT, "0"), (DataType.INT, "0"))
            };

            // Inject user's code into solution template and evaluate
            string fullCode = $@"
                public static class Solution {{
                    public static int Add(int a, int b) {{
                        {code}
                    }}
                }}";

            var passedTestCases = new List<string>();

            foreach (var testcase in testCases) {
                int result = Solution.Add(
                        int.Parse(testcase.Inputs[0].Item2),
                        int.Parse(testcase.Inputs[1].Item2)
                );

                if (result == testcase.Output) {
                    passedTestCases.Add($"Passed for inputs {string.Join(", ", testcase.Inputs.Select(i => i.Item2))}");
                } else {
                    passedTestCases.Add($"Failed for inputs {string.Join(", ", testcase.Inputs.Select(i => i.Item2))}. Expected {testcase.Output}, but got {result}");
                    break;
                }
            }

            return Json(new { result = passedTestCases });
        }*/

    }
}
