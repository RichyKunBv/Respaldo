using Microsoft.Extensions.DependencyInjection;

namespace Presentacion;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // ¡Aquí está la magia! 
        // Quitamos AppShell y pasamos directamente tu MainPage
        return new Window(new MainPage());
    }
}