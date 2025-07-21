using Transaction_Flow.Model;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Transaction_Flow.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            var conn = _context.Database.GetDbConnection();
            Debug.WriteLine("DB Path: " + conn.DataSource);
        }
        public UserModel? GetUserByLogin(string username, string password)
        {

            var allUsers = _context.Users.ToList();
            foreach (var u in allUsers)
            {
                Debug.WriteLine($"DB User: {u.Username}, {u.Password}, {u.PreferredCurrency}");
            }

            return _context.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }


    }
}
