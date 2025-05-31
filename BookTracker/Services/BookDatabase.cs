using SQLite;
using BookTracker.Models;

namespace BookTracker.Services
{
    public class BookDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BookDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
        }

        public Task<List<Book>> GetBooksAsync() => _database.Table<Book>().ToListAsync();
        public Task<Book> GetBookAsync(int id) => _database.Table<Book>().Where(b => b.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveBookAsync(Book book) => book.Id != 0 ? _database.UpdateAsync(book) : _database.InsertAsync(book);
        public Task<int> DeleteBookAsync(Book book) => _database.DeleteAsync(book);
    }
}
