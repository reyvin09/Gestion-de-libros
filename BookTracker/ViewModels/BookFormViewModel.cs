using BookTracker.Models;
using BookTracker.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BookTracker.ViewModels
{
    public class BookFormViewModel : INotifyPropertyChanged
    {
        private readonly BookDatabase _db;
        public Book Book { get; set; } = new();
        public string PageTitle => Book.Id == 0 ? "Nuevo Libro" : "Editar Libro";

        public ICommand SaveCommand { get; }

        public event EventHandler BookSaved;
        public event PropertyChangedEventHandler PropertyChanged;

        public BookFormViewModel(BookDatabase db)
        {
            _db = db;
            SaveCommand = new Command(async () => await SaveAsync());
        }

        public void LoadBook(Book book)
        {
            Book = book ?? new Book();
            OnPropertyChanged(nameof(Book));
            OnPropertyChanged(nameof(PageTitle));
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Book.Title) || string.IsNullOrWhiteSpace(Book.Author))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Título y autor son obligatorios.", "OK");
                return;
            }

            await _db.SaveBookAsync(Book);
            BookSaved?.Invoke(this, EventArgs.Empty);
        }

        void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
