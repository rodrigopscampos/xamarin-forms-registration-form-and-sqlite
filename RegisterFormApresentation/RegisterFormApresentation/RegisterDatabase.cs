using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterFormApresentation
{
    public class RegisterDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RegisterDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RegistrationModel>().Wait();
        }

        public async void Add(RegistrationModel item)
        {
            await _database.InsertAsync(item);
        }

        public Task<List<RegistrationModel>> GetAll()
        {
            return _database.Table<RegistrationModel>().ToListAsync();
        }
    }
}