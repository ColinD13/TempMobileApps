using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace PersonalProject.Models
{
	[Table("Card")]
	public class Card
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

        //Player Name
        private string _playerName;
		public string playerName
		{
			get { return _playerName; }
			set { _playerName = value;
				OnPropertyChanged("playerName");
			}
		}

		//Card Brand
		private string _brand;
		public string brand
		{
			get { return _brand; }
			set { _brand = value;
                OnPropertyChanged("brand");
            }
		}

		//Set
		private string _brandSet;

		public string brandSet
		{
			get { return _brandSet; }
			set { _brandSet = value;
                OnPropertyChanged("brandSet");
            }
		}

		private int _cardID;

		[PrimaryKey]
		public int cardID
		{
			get { return _cardID; }
			set { _cardID = value;
                OnPropertyChanged("cardID");
            }
		}

		//Constructor
		public Card(){
			this._playerName = "";
			this._brand = "";
			this._brandSet = "";
			this._cardID = 0;
		}

		public Card(string playerName, string brand, string brandSet, int cardID)
		{
			_playerName = playerName;
			_brand = brand;
			_brandSet = brandSet;
			_cardID = cardID;
		}
	}
}
