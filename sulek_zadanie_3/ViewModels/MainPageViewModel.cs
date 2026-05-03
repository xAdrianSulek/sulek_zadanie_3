using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sulek_zadanie_3.Models;
using sulek_zadanie_3.Services;

namespace sulek_zadanie_3.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ITransactionStore _store;

        public ObservableCollection<Transaction> Transactions => _store.Transactions;

        public MainPageViewModel(ITransactionStore store)
        {
            _store = store;
            _store.Transactions.CollectionChanged += OnTransactionsChanged;
        }

        public decimal TotalIncome =>
            Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);

        public decimal TotalExpenses =>
            Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);

        public decimal Balance => TotalIncome - TotalExpenses;

        [RelayCommand]
        private async Task GoToSecondAsync()
        {
            await Shell.Current.GoToAsync("SecondPage");
        }

        [RelayCommand]
        private async Task GoToThirdAsync()
        {
            await Shell.Current.GoToAsync("ThirdPage");
        }

        [RelayCommand]
        private async Task GoToFourthAsync()
        {
            await Shell.Current.GoToAsync("FourthPage");
        }

        private void OnTransactionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalIncome));
            OnPropertyChanged(nameof(TotalExpenses));
            OnPropertyChanged(nameof(Balance));
        }
    }
}
