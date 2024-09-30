using AssignmentConsole.Model;
using AssignmentWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebApplication.Controllers {
    [Route("Student")]
    public class StudentController : Controller {
        private readonly DataContext context;

        public StudentController(DataContext context) {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var students = await context.Students.ToListAsync();
            return View(students);
        }

        [HttpGet("List")]
        public async Task<ActionResult<Student>> GetStudents() {
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id) {
            var student = await context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,Name,Semester")] Student student) {
            if (ModelState.IsValid) {
                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [Route("Create")]
        public IActionResult Create() {
            return View();
        }

    }
}