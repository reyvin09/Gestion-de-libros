using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookTracker.Models;
using BookTracker.Services;
using System.Collections.ObjectModel;

namespace BookTracker.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly BookDatabase _db;

        public int TotalBooks { get; set; }
        public int ReadBooks { get; set; }
        public int InProgressBooks { get; set; }
        public int ToReadBooks { get; set; }

        public DashboardViewModel(BookDatabase db)
        {
            _db = db;
            LoadStats();
        }

        public async void LoadStats()
        {
            var books = await _db.GetBooksAsync();
            TotalBooks = books.Count;
            ReadBooks = books.Count(b => b.Status == "Leído");
            InProgressBooks = books.Count(b => b.Status == "En lectura");
            ToReadBooks = books.Count(b => b.Status == "Por leer");
            OnPropertyChanged(nameof(TotalBooks));
            OnPropertyChanged(nameof(ReadBooks));
            OnPropertyChanged(nameof(InProgressBooks));
            OnPropertyChanged(nameof(ToReadBooks));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
