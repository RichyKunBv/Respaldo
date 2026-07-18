namespace Presentacion;

public partial class Sobre_Mi : ContentPage
{
    public Sobre_Mi()
    {
        InitializeComponent();
    }

    private async void OnContactarClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("Contacto", "Abriendo cliente de correo para enviar un mensaje...", "OK");
    }

    private async void OnRedSocialClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("Red Social", "Redirigiendo al perfil profesional...", "Cerrar");
    }
}