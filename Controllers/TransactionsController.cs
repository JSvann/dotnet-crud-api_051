using dotnet_crud_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crud_api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        // Menggunakan list statis untuk simulasi database.
        private static readonly List<Transaction> _transactions = new List<Transaction>
        {
            new Transaction { Id = 1, Description = "Belanja Mingguan", Amount = 250000, Date = DateTime.Now, BudgetId = 1 },
            new Transaction { Id = 2, Description = "Isi Bensin", Amount = 50000, Date = DateTime.Now, BudgetId = 2 }
        };

        // --- ACTION BACA (READ) ---

        // GET: api/transactions
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            return Ok(_transactions);
        }

        // GET: api/transactions/1
        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // --- ACTION TULIS (WRITE) ---

        // POST: api/transactions
        [HttpPost]
        public ActionResult<Transaction> CreateTransaction([FromBody] Transaction newTransaction)
        {
            newTransaction.Id = _transactions.Max(t => t.Id) + 1;
            _transactions.Add(newTransaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = newTransaction.Id }, newTransaction);
        }

        // PUT: api/transactions/1
        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, [FromBody] Transaction updatedTransaction)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            transaction.Description = updatedTransaction.Description;
            transaction.Amount = updatedTransaction.Amount;
            transaction.Date = updatedTransaction.Date;
            transaction.BudgetId = updatedTransaction.BudgetId;

            return NoContent();
        }

        // DELETE: api/transactions/1
        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            _transactions.Remove(transaction);
            return NoContent();
        }
    }
}