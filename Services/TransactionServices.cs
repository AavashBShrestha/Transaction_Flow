using Microsoft.EntityFrameworkCore;
using Transaction_Flow.Model;

namespace Transaction_Flow.Services
{
    public class TransactionServices
    {
        private readonly AppDbContext _context;

        public TransactionServices(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<List<TransactionModel>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync(); // Get all transactions from DB
        }

        public async Task SaveTransaction(TransactionModel transaction)
        {
            if (transaction.Id == 0)
            {
                _context.Transactions.Add(transaction); // Add new transaction
            }
            else
            {
                var existing = await _context.Transactions.FindAsync(transaction.Id);
                if (existing != null)
                {
                    existing.Title = transaction.Title;
                    existing.TransactionType = transaction.TransactionType;
                    existing.Amount = transaction.Amount;
                    existing.Tags = transaction.Tags;
                    existing.Date = transaction.Date;
                }
            }

            await _context.SaveChangesAsync(); // Save changes to the database
        }

        public async Task DeleteTransaction(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
