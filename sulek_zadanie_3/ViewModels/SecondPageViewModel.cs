using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sulek_zadanie_3.Models;
using sulek_zadanie_3.Services;

namespace sulek_zadanie_3.ViewModels
{
    public partial class SecondPageViewModel : ObservableObject
    {
        private readonly ITransactionStore _store;

        public ObservableCollection<Transaction> Transactions => _store.Transactions;

        public SecondPageViewModel(ITransactionStore store)
        {
            _store = store;
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task GoToThirdAsync()
        {
            await Shell.Current.GoToAsync("//MainPage/SecondPage/ThirdPage");
        }

        [RelayCommand]
        private async Task GoToFourthAsync()
        {
            await Shell.Current.GoToAsync("//MainPage/SecondPage/FourthPage");
        }

        [RelayCommand]
        private async Task DeleteAsync(Transaction? transaction)
        {
            if (transaction is null)
                return;

            await _store.RemoveAsync(transaction);
        }
    }
}
