using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PersonalProject.Models;

namespace PersonalProject.ViewModels
{
    public class CardDatabase
    {
        private SQLiteConnection _connection;
        private string _dbPath;

        private void init()
        {
            if (_connection != null)
            {
                return;
            }

            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Card>();
        }

        public CardDatabase(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async void InsertCard(Card newCard)
        {
            int result = 0;

            try
            {
                init();
                if (newCard.cardID != 0)
                {
                    result = _connection.Insert(newCard);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("DB Error", ex.ToString(), "OK");
            }//end try catch
        }

        public List<Card> GetCards()
        {
            try
            {
                init();
                return _connection.Table<Card>().ToList();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Read error", ex.ToString(), "Exit");
            }

            return new List<Card>();
        }
    }
}
