using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.Models;

namespace PersonalProject.ViewModels
{
    public class CardViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }

        //Command 
        public Command NewCardCommand { get; set; }

        //Card to Add
        private Card _newCard;

        public Card newCard
        {
            get { return _newCard; }
            set { _newCard = value; }
        }

        //Constructor
        public CardViewModel()
        {
            _newCard = new Card();

            NewCardCommand = new Command(NewCard);
        }

        //new Card method

        public async void NewCard()
        {
            bool saveIt = await App.Current.MainPage.DisplayAlert("Add Card?", "Save and make new Card?", "Yes", "No");

            if (saveIt)
            {

                App.cardDatabase.InsertCard(_newCard);
                _newCard.playerName = "";
                _newCard.brand = "";
                _newCard.brandSet = "";
                _newCard.cardID = 0;

            }
        }



    }
}
