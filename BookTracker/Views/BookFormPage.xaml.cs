using BookTracker.Models;
using BookTracker.Services;
using BookTracker.ViewModels;

namespace BookTracker.Views;

public partial class BookFormPage : ContentPage
{
    private BookFormViewModel ViewModel;

    public BookFormPage(Book book = null)
    {
        InitializeComponent();

        var db = new BookDatabase(Path.Combine(FileSystem.AppDataDirectory, "books.db3"));
        ViewModel = new BookFormViewModel(db);
        ViewModel.LoadBook(book);
        ViewModel.BookSaved += OnBookSaved;

        BindingContext = ViewModel;
    }

    private async void OnBookSaved(object sender, EventArgs e)
    {
        await DisplayAlert("Éxito", "Libro guardado correctamente.", "OK");
        await Navigation.PopAsync();
    }
}
