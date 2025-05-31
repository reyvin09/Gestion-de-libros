using BookTracker.Models;
using BookTracker.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookTracker.ViewModels
{
    public class StatsViewModel : INotifyPropertyChanged
    {
        private readonly BookDatabase _db;

        public int TotalBooks { get; set; }
        public int ToReadCount { get; set; }
        public int ReadingCount { get; set; }
        public int ReadCount { get; set; }

        public StatsViewModel(BookDatabase db)
        {
            _db = db;
            LoadStats();
        }

        public async void LoadStats()
        {
            var books = await _db.GetBooksAsync();
            TotalBooks = books.Count;
            ToReadCount = books.Count(b => b.Status == "Por leer");
            ReadingCount = books.Count(b => b.Status == "En lectura");
            ReadCount = books.Count(b => b.Status == "Leído");

            OnPropertyChanged(nameof(TotalBooks));
            OnPropertyChanged(nameof(ToReadCount));
            OnPropertyChanged(nameof(ReadingCount));
            OnPropertyChanged(nameof(ReadCount));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
