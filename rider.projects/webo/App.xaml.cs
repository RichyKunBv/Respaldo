using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using webo.Pages;

namespace webo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new Pagina1());
	}
}