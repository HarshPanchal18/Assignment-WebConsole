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

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNo,Name,Semester")] Student student) {
            if (ModelState.IsValid) {
                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet("Create")]
        public IActionResult Create() {
            return View();
        }

        // GET: /Student/Edit/2
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null)
                return NotFound();

            var student = await context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: /Student/Edit/2
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RollNo,Name,Semester")] Student student) {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid) {
                context.Students.Update(student);
                await context.SaveChangesAsync();
                try {
                } catch (DbUpdateConcurrencyException) {
                    if (!StudentExists(student.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: /Student/Delete/2
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();

            var student = await context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: /Student/Delete/2
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            var student = await context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id) {
            return context.Students.Any(e => e.Id == id);
        }

    }
}