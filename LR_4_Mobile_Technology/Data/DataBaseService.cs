using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar_Card.Data
{
	public class DataBaseService
	{
		private readonly SQLiteAsyncConnection? _database;

		public DataBaseService(string dbPath)
		{
			this._database = new SQLiteAsyncConnection(dbPath);
			this._database.CreateTableAsync<Drinks>();
		}
		public Task<List<Drinks>> GetDrinkAsync()
		{
			return _database.Table<Drinks>().ToListAsync();
		}
		public Task<int> SaveDrinkAsync(Drinks drink)
		{
			return _database.InsertAsync(drink);
		}
		public Task<int> UpdateDrinkAsync(Drinks drink)
		{
			return _database.UpdateAsync(drink);
		}
		public Task<int> DeleteDrinkAsync(Drinks drink)
		{
			return _database.DeleteAsync(drink);
		}
	}
}
