using SQLite;

namespace Transaction_Flow.Model
{
    public class DebtModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string? Source { get; set; }
        [NotNull]
        public double Amount { get; set; }
        [NotNull]
        public DateTime DueDate { get; set; }
        public bool IsCleared { get; set; }
    }

}
