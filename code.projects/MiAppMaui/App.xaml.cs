using MiAppMaui.Pages;

namespace MiAppMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginPage();
	}
}
