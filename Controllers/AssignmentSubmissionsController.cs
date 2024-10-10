using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssignmentWebApplication.Model;
using AssignmentWebApplication.Data;

namespace AssignmentWebApplication.Controllers {
    public class AssignmentSubmissionsController : Controller {
        private readonly DataContext _context;

        public AssignmentSubmissionsController(DataContext context) {
            _context = context;
        }

        // GET: AssignmentSubmissions
        public async Task<IActionResult> Index() {
            return View(await _context.AssignmentSubmission.ToListAsync());
        }

        // GET: AssignmentSubmissions/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var assignmentSubmission = await _context.AssignmentSubmission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignmentSubmission == null) {
                return NotFound();
            }

            return View(assignmentSubmission);
        }

        // GET: AssignmentSubmissions/Create
        public IActionResult Create() {
            return View();
        }

        // POST: AssignmentSubmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssignmentId,StudentId,SubmissionDate,Content,IsSubmitted")] AssignmentSubmission assignmentSubmission) {
            if (ModelState.IsValid) {
                _context.Add(assignmentSubmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignmentSubmission);
        }

        // GET: AssignmentSubmissions/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var assignmentSubmission = await _context.AssignmentSubmission.FindAsync(id);
            if (assignmentSubmission == null) {
                return NotFound();
            }
            return View(assignmentSubmission);
        }

        // POST: AssignmentSubmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignmentId,StudentId,SubmissionDate,Content,IsSubmitted")] AssignmentSubmission assignmentSubmission) {
            if (id != assignmentSubmission.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(assignmentSubmission);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!AssignmentSubmissionExists(assignmentSubmission.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assignmentSubmission);
        }

        // GET: AssignmentSubmissions/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var assignmentSubmission = await _context.AssignmentSubmission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignmentSubmission == null) {
                return NotFound();
            }

            return View(assignmentSubmission);
        }

        // POST: AssignmentSubmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var assignmentSubmission = await _context.AssignmentSubmission.FindAsync(id);
            if (assignmentSubmission != null) {
                _context.AssignmentSubmission.Remove(assignmentSubmission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentSubmissionExists(int id) {
            return _context.AssignmentSubmission.Any(e => e.Id == id);
        }
    }
}
