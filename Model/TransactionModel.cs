using SQLite;
using System.Text.Json;

namespace Transaction_Flow.Model
{
    public class TransactionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string? Title { get; set; }

        [NotNull]
        public double? Amount { get; set; }

        [NotNull]
        public string TransactionType { get; set; } 

        private string _tags; 

        [Ignore]
        public string[] Tags
        {
            get => string.IsNullOrEmpty(_tags) ? new string[] { } : JsonSerializer.Deserialize<string[]>(_tags); // Deserialize the JSON string to array
            set => _tags = JsonSerializer.Serialize(value); // Serialize array to JSON string
        }

        public string? Note { get; set; }

        [NotNull]
        public DateTime Date { get; set; }

        // Constructor for default tags
        public TransactionModel()
        {
            Tags = new string[]
            {
                "Yearly", "Monthly", "Food", "Drinks", "Clothes", "Gadgets", "Miscellaneous", "Fuel", "Rent", "EMI", "Party"
            };
        }
    }
}
