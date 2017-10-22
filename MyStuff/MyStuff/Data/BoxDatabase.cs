using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MyStuff
{
    public class BoxDatabase
    {
        readonly SQLiteAsyncConnection database;

        public BoxDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Box>().Wait();
        }

        public Task<List<Box>> GetItemsAsync()
        {
            return database.Table<Box>().ToListAsync();
        }

        public Task<List<Box>> GetItemsWithName(string name)
        {
            return database.QueryAsync<Box>("SELECT * FROM [Box] WHERE [Name] = \'" + name + "\'");
        }

        public Task<Box> GetItemAsync(int id)
        {
            return database.Table<Box>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Box box)
        {
            if (box.ID != 0)
            {
                return database.UpdateAsync(box);
            }
            else
            {
                return database.InsertAsync(box);
            }
        }

        public Task<int> DeleteItemAsync(Box box)
        {
            return database.DeleteAsync(box);

        }
    }
}