using PersonalProject.ViewModels;

namespace PersonalProject;

public partial class App : Application
{
    public static CardDatabase cardDatabase;
    public App(CardDatabase database)
	{
		InitializeComponent();

		MainPage = new AppShell();
		cardDatabase = database;
	}
}
