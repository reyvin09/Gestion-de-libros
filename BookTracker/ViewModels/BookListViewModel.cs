using BookTracker.Models;
using BookTracker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookTracker.ViewModels
{
    public class BookListViewModel : INotifyPropertyChanged
    {
        private readonly BookDatabase _db;

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public BookListViewModel(BookDatabase db)
        {
            _db = db;
        }

        public async void LoadBooks()
        {
            Books.Clear();
            var books = await _db.GetBooksAsync();

            Console.WriteLine($"Cargando {books.Count} libros"); // 👈 esto te muestra cuántos se están cargando

            foreach (var book in books)
            {
                Books.Add(book);
            }
        }


        public Command<Book> DeleteCommand => new Command<Book>(async (book) =>
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmar", $"¿Eliminar \"{book.Title}\"?", "Sí", "No");

            if (confirm)
            {
                await _db.DeleteBookAsync(book);
                LoadBooks();
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        internal async Task DeleteBook(Book bookToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
