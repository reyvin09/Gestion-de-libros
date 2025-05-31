using BookTracker.Services;
using BookTracker.ViewModels;

namespace BookTracker.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var db = new BookDatabase(Path.Combine(FileSystem.AppDataDirectory, "books.db3"));
        BindingContext = new DashboardViewModel(db);
    }
}
