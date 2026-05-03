using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sulek_zadanie_3.Models;
using sulek_zadanie_3.Services;

namespace sulek_zadanie_3.ViewModels
{
    public partial class FourthPageViewModel : ObservableObject
    {
        private readonly ITransactionStore _store;

        public FourthPageViewModel(ITransactionStore store)
        {
            _store = store;
            _store.Transactions.CollectionChanged += OnTransactionsChanged;
        }

        public IEnumerable<CategoryTotal> ExpensesByCategory =>
            _store.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category)
                .Select(g => new CategoryTotal(g.Key, g.Sum(t => t.Amount)))
                .OrderByDescending(c => c.Total);

        public decimal TotalExpenses =>
            _store.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

        public decimal TotalIncome =>
            _store.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

        private void OnTransactionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ExpensesByCategory));
            OnPropertyChanged(nameof(TotalExpenses));
            OnPropertyChanged(nameof(TotalIncome));
        }

        [RelayCommand]
        private async Task GoToMainAsync()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        [RelayCommand]
        private async Task GoToSecondAsync()
        {
            await Shell.Current.GoToAsync("//MainPage/SecondPage");
        }

        [RelayCommand]
        private async Task GoToThirdAsync()
        {
            await Shell.Current.GoToAsync("//MainPage/ThirdPage");
        }
    }
}
