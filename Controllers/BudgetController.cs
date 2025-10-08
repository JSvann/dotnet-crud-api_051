using dotnet_crud_api.Models;
using Microsoft.AspNetCore.Mvc; 

namespace dotnet_crud_api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        // Menggunakan list statis untuk simulasi database pada contoh ini.
        private static readonly List<Budget> _budgets = new List<Budget>
        {
            new Budget { Id = 1, Name = "Anggaran Makanan Oktober", Amount = 3000000, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 31) },
            new Budget { Id = 2, Name = "Anggaran Transportasi Oktober", Amount = 500000, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 31) }
        };

        // --- ACTION BACA (READ) ---

        // GET: api/budgets
        [HttpGet]
        public ActionResult<IEnumerable<Budget>> GetBudgets()
        {
            return Ok(_budgets);
        }

        // GET: api/budgets/1
        [HttpGet("{id}")]
        public ActionResult<Budget> GetBudgetById(int id)
        {
            var budget = _budgets.FirstOrDefault(b => b.Id == id);
            if (budget == null)
            {
                return NotFound(); // Mengembalikan 404 jika tidak ditemukan
            }
            return Ok(budget);
        }

        // --- ACTION TULIS (WRITE) ---

        // POST: api/budgets
        [HttpPost]
        public ActionResult<Budget> CreateBudget([FromBody] Budget newBudget)
        {
            newBudget.Id = _budgets.Max(b => b.Id) + 1; // Membuat ID sederhana
            _budgets.Add(newBudget);
            return CreatedAtAction(nameof(GetBudgetById), new { id = newBudget.Id }, newBudget);
        }

        // PUT: api/budgets/1
        [HttpPut("{id}")]
        public IActionResult UpdateBudget(int id, [FromBody] Budget updatedBudget)
        {
            var budget = _budgets.FirstOrDefault(b => b.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            budget.Name = updatedBudget.Name;
            budget.Amount = updatedBudget.Amount;
            budget.StartDate = updatedBudget.StartDate;
            budget.EndDate = updatedBudget.EndDate;

            return NoContent(); // Mengembalikan 204 sebagai tanda sukses tanpa konten
        }

        // DELETE: api/budgets/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBudget(int id)
        {
            var budget = _budgets.FirstOrDefault(b => b.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            _budgets.Remove(budget);
            return NoContent();
        }
    }
}