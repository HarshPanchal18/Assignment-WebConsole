using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssignmentWebApplication.Model;
using AssignmentWebApplication.Data;

namespace AssignmentWebApplication.Controllers {
    [Route("Teachers")]
    public class TeachersController : Controller {
        private readonly DataContext context;

        public TeachersController(DataContext context) {
            this.context = context;
        }

        // GET: Teachers
        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await context.Teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null)
                return NotFound();

            var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        // GET: Teachers/Create
        [HttpGet("Create")]
        public IActionResult Create() => View();

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Department")] Teacher teacher) {
            if (ModelState.IsValid) {
                context.Add(teacher);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null)
                return NotFound();

            var teacher = await context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id) {
            var teacher = await context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Department")] Teacher teacher) {
            if (id != teacher.Id)
                return NotFound();

            if (ModelState.IsValid) {
                try {
                    context.Update(teacher);
                    await context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!TeacherExists(teacher.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();

            var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            var teacher = await context.Teachers.FindAsync(id);
            if (teacher != null)
                context.Teachers.Remove(teacher);

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id) => context.Teachers.Any(e => e.Id == id);

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id) {

            var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

    }
}
