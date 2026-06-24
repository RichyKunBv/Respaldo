using Microsoft.Extensions.DependencyInjection;
using MauiApp1.Pages;
using Microsoft.Maui.Controls.Xaml;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new LoginPage());
	}
}