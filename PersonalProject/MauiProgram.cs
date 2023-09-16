using Microsoft.Extensions.Logging;
using PersonalProject.ViewModels;

namespace PersonalProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "people.db3");
        builder.Services.AddSingleton<CardDatabase>(s => ActivatorUtilities.CreateInstance<CardDatabase>(s, dbPath));
        return builder.Build();
	}
}
