using Microsoft.AspNetCore.Mvc;
using WebTracNghiem.Models;
using WebTracNghiem.Repositories;

namespace WebTracNghiem.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamRepositories _examRepository;

        public ExamController(IExamRepositories examRepository)
        {
            _examRepository = examRepository;
        }

        // GET: /Exam
        public async Task<IActionResult> Index()
        {
            var questions = await _examRepository.GetAllAsync();
            return View(questions);
        }

        // GET: /Exam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Exam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question)
        {
            if (ModelState.IsValid)
            {
                await _examRepository.AddAsync(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: /Exam/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var question = await _examRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: /Exam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                await _examRepository.UpdateAsync(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: /Exam/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _examRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: /Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Exam/Start
        public async Task<IActionResult> Start()
        {
            var questions = await _examRepository.GetAllAsync(); // Lấy toàn bộ câu hỏi
            var model = new ExamViewModel
            {
                Questions = questions.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(ExamViewModel model)
        {
            int score = 0;
            foreach (var q in model.Questions)
            {
                if (model.UserAnswers.TryGetValue(q.Id, out var answer) && answer == q.CorrectAnswer)
                {
                    score++;
                }
            }

            ViewBag.Score = score;
            ViewBag.Total = model.Questions.Count;

            return View("Result");
        }

    }
}
