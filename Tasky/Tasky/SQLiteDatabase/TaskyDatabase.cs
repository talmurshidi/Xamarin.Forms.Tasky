using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasky.Models;

namespace Tasky.SQLiteDatabase
{
    public class TaskyDatabase
    {
        readonly SQLiteAsyncConnection database;
        public TaskyDatabase( string dbPath )
        {
            database = new SQLiteAsyncConnection( dbPath );
            database.CreateTableAsync<TaskyModel>().Wait();
        }

        public Task<List<TaskyModel>> GetItemsAsync()
        {
            return database.Table<TaskyModel>().ToListAsync();
        }

        public Task<List<TaskyModel>> GetItemsNotDoneAsync()
        {
            return database.Table<TaskyModel>().Where( i => i.IsDone == false ).ToListAsync();
            //return database.QueryAsync<TaskyModel>( "SELECT * FROM [TaskyModel] WHERE [IsDone] = 0" );
        }

        public Task<TaskyModel> GetItemAsync( int id )
        {
            return database.Table<TaskyModel>().Where( i => i.ID == id ).FirstOrDefaultAsync();
        }

        public Task<int> InsertItemAsync( TaskyModel item )
        {
            return database.InsertAsync( item );
        }

        public Task<int> UpdateItemAsync( TaskyModel item )
        {
            return database.UpdateAsync( item );
        }

        public Task<int> DeleteItemAsync( TaskyModel item )
        {
            return database.DeleteAsync( item );
        }
    }
}
