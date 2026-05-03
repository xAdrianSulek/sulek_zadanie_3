using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using sulek_zadanie_3.Models;

namespace sulek_zadanie_3.Services
{
    public class JsonTransactionStore : ITransactionStore
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public ObservableCollection<Transaction> Transactions { get; }

        public JsonTransactionStore()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");
            Transactions = new ObservableCollection<Transaction>(Load());
        }

        public async Task AddAsync(Transaction transaction)
        {
            Transactions.Add(transaction);
            await SaveAsync();
        }

        public async Task RemoveAsync(Transaction transaction)
        {
            if (Transactions.Remove(transaction))
                await SaveAsync();
        }

        private List<Transaction> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Transaction>();

            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Transaction>>(json, _jsonOptions)
                       ?? new List<Transaction>();
            }
            catch
            {
                return new List<Transaction>();
            }
        }

        private async Task SaveAsync()
        {
            var json = JsonSerializer.Serialize(Transactions, _jsonOptions);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
