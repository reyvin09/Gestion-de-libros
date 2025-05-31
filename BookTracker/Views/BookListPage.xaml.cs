using BookTracker.Models;
using BookTracker.Services;
using BookTracker.ViewModels;

namespace BookTracker.Views;

public partial class BookListPage : ContentPage
{
    private BookListViewModel ViewModel;

    public BookListPage()
    {
        InitializeComponent();

        var db = new BookDatabase(Path.Combine(FileSystem.AppDataDirectory, "books.db3"));
        ViewModel = new BookListViewModel(db);
        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.LoadBooks();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        // Navegar al formulario vacío para crear nuevo libro
        await Navigation.PushAsync(new BookFormPage());
    }


    private async void OnDeleteSwipe(object sender, EventArgs e)
    {
        var swipeItem = (SwipeItem)sender;
        var bookToDelete = (Book)swipeItem.CommandParameter;

        bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar '{bookToDelete.Title}'?", "Sí", "No");
        if (confirm)
            await ViewModel.DeleteBook(bookToDelete);
    }
}
