using PersonalProject.Models;

namespace PersonalProject.Views;

public partial class DataPage : ContentPage
{
	public DataPage()
	{
		InitializeComponent();
	}

	public void FillList(object sender, EventArgs e)
    {
        List<Card> cards = App.cardDatabase.GetCards().ToList();
        cardList.ItemsSource = cards;
    }
}