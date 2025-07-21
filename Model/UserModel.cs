using SQLite;

namespace Transaction_Flow.Model
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, NotNull]
        public string? Username { get; set; }
        [NotNull]
        public string? Password { get; set; }
        [NotNull]
        public string? PreferredCurrency { get; set; }
    }
}
