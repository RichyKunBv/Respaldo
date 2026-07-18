namespace Carreras.Pages;

public partial class PsicPage : ContentPage
{
    // Variable estática para recordar la fecha incluso si la página se recarga
    private static DateTime? _fechaUltimaVisita;

    public PsicPage()
    {
        InitializeComponent();
    }

    // Se ejecuta cada vez que entras a la pestaña
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_fechaUltimaVisita.HasValue)
        {
            // Si ya tiene un valor, lo mostramos
            LblUltimaVisita.Text = $"Última visita: {_fechaUltimaVisita.Value.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
        else
        {
            LblUltimaVisita.Text = "Esta es tu primera visita a esta página.";
        }
    }

    // Se ejecuta cada vez que sales de la pestaña
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        // Guardamos la hora actual exacta al salir
        _fechaUltimaVisita = DateTime.Now;
    }
}