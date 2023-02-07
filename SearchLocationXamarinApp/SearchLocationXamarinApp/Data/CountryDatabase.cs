using SearchLocationXamarinApp.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Data
{
    public class CountryDatabase
    {
        private readonly SQLiteAsyncConnection dataBase;

        public CountryDatabase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Country>().Wait();
        }

        public async Task<ObservableCollection<Country>> GetItemsAsync()
        {
            try
            {
                return new ObservableCollection<Country>(await dataBase.Table<Country>().ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ObservableCollection<Country>();
            }
        }


        public bool SaveItemListAsync(ObservableCollection<Country> itemList)
        {
            try
            {
                dataBase.InsertAllAsync(itemList);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
    }
}
