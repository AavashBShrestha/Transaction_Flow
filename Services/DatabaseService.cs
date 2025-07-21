using Transaction_Flow.Model;
using SQLite;

public class DatabaseService
{
    private readonly SQLiteConnection _dbConnection;

    public DatabaseService(string DbPath)
    {
        try
        {
            _dbConnection = new SQLiteConnection(DbPath);
            Console.WriteLine("Database connection initialized successfully.");

            _dbConnection.CreateTable<UserModel>();
            _dbConnection.CreateTable<TransactionModel>();
            _dbConnection.CreateTable<DebtModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database initialization failed: {ex.Message}");
            throw new InvalidOperationException("Could not initialize the database.", ex);
        }
    }

    public SQLiteConnection GetConnection() => _dbConnection;

    public void AddUser(UserModel user)
    {
        _dbConnection.Insert(user);
    }

    public UserModel GetUser(string username)
    {
        return _dbConnection.Table<UserModel>().FirstOrDefault(u => u.Username == username);
    }

    public async Task AddTransaction(TransactionModel transaction)
    {
        if (string.IsNullOrEmpty(transaction.Title))
        {
            Console.WriteLine("Transaction title cannot be null or empty.");
            return;
        }

        try
        {
            await Task.Run(() => _dbConnection.Insert(transaction));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding transaction: {ex.Message}");
        }
    }

    public List<TransactionModel> GetTransactions()
    {
        return _dbConnection.Table<TransactionModel>().ToList();
    }

    public void Dispose()
    {
        _dbConnection?.Close();
    }
}
