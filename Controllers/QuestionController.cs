using AssignmentWebApplication.Data;
using AssignmentWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebApplication.Controllers {
    [Route("Question")]
    public class QuestionController : Controller {
        private readonly DataContext context;

        public QuestionController(DataContext context) {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var questions = await context.Questions.ToListAsync();
            return View(questions);
        }

        [HttpGet("Create")]
        public IActionResult Create() {
            return View();
        }

        // POST: Question/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question) {
            if (ModelState.IsValid) {
                question.CreatedAt = DateTime.Now;
                context.Add(question);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to your index page or another page
            }
            return View(question);
        }

        // GET: /Student/Edit/2
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null)
                return NotFound();

            var student = await context.Questions.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: /Student/Edit/2
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignmentId,Description,Status,Deleted,CreationTimestamp,UpdationTimestamp,DeletionTimestamp,FunctionSignature,ParameterCount")] Question question) {

            if (id != question.Id)
                return NotFound();

            if (ModelState.IsValid) {
                question.UpdatedAt = DateTime.Now;
                context.Questions.Update(question);
                await context.SaveChangesAsync();
                try {
                } catch (DbUpdateConcurrencyException) {
                    if (!QuestionExists(question.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(question);
        }

        // GET: /Question/Delete/2
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();

            var question = await context.Questions.FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
                return NotFound();

            return View(question);
        }

        // POST: /Student/Delete/2
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            var question = await context.Questions.FindAsync(id);
            if (question == null)
                return NotFound();

            question.IsDeleted = true;
            question.DeletedAt = DateTime.Now;
            context.Questions.Update(question);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id) => context.Questions.Any(e => e.Id == id);

        // GET: Question/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id) {
            if (id == null)
                return NotFound();

            var question = await context.Questions.FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
                return NotFound();

            return View(question);
        }
    }
}
