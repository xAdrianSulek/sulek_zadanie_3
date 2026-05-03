using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sulek_zadanie_3.Models;
using sulek_zadanie_3.Services;

namespace sulek_zadanie_3.ViewModels
{
    public partial class ThirdPageViewModel : ObservableObject
    {
        private readonly ITransactionStore _store;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private decimal amount;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string category = string.Empty;

        [ObservableProperty]
        private DateTime date = DateTime.Today;

        [ObservableProperty]
        private TransactionType type = TransactionType.Expense;

        [ObservableProperty]
        private string? note;

        public IReadOnlyList<TransactionType> TransactionTypes { get; } =
            Enum.GetValues<TransactionType>();

        public ThirdPageViewModel(ITransactionStore store)
        {
            _store = store;
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveAsync()
        {
            var transaction = new Transaction
            {
                Amount = Amount,
                Category = Category.Trim(),
                Date = Date,
                Type = Type,
                Note = string.IsNullOrWhiteSpace(Note) ? null : Note
            };

            await _store.AddAsync(transaction);
            ResetForm();
            await Shell.Current.GoToAsync("//MainPage");
        }

        private bool CanSave() =>
            Amount >= 0 && !string.IsNullOrWhiteSpace(Category);

        private void ResetForm()
        {
            Amount = 0;
            Category = string.Empty;
            Date = DateTime.Today;
            Type = TransactionType.Expense;
            Note = null;
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
        private async Task GoToFourthAsync()
        {
            await Shell.Current.GoToAsync("//MainPage/ThirdPage/FourthPage");
        }
    }
}
