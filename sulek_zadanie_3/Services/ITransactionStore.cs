using System.Collections.ObjectModel;
using sulek_zadanie_3.Models;

namespace sulek_zadanie_3.Services
{
    public interface ITransactionStore
    {
        ObservableCollection<Transaction> Transactions { get; }
        Task AddAsync(Transaction transaction);
        Task RemoveAsync(Transaction transaction);
    }
}
