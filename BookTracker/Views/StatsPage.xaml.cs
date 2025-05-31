using BookTracker.Services;
using BookTracker.ViewModels;

namespace BookTracker.Views;

public partial class StatsPage : ContentPage
{
    private StatsViewModel ViewModel;

    public StatsPage()
    {
        InitializeComponent();

        var db = new BookDatabase(Path.Combine(FileSystem.AppDataDirectory, "books.db3"));
        ViewModel = new StatsViewModel(db);
        BindingContext = ViewModel;
    }
}
