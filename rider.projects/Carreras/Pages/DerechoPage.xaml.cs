namespace Carreras.Pages;

public partial class DerechoPage : ContentPage
{
    private static DateTime? _fechaUltimaVisita;

    public DerechoPage()
    {
        // ¡Ahora sí va a reconocer esto!
        InitializeComponent(); 
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_fechaUltimaVisita.HasValue)
        {
            // ¡Y también reconocerá LblUltimaVisita!
            LblUltimaVisita.Text = $"Última visita: {_fechaUltimaVisita.Value.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
        else
        {
            LblUltimaVisita.Text = "Esta es tu primera visita a esta página.";
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _fechaUltimaVisita = DateTime.Now;
    }
}