namespace Presentacion;

public partial class MainPage : FlyoutPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnMenuItemClicked(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            Page page = btn.Text switch
            {
                "Sobre mí" => new Sobre_Mi(),
                "Educación" => new Educacion(),
                "Experiencia laboral" => new ExperienciaLaboral(),
                "Proyectos" => new Proyectos(),
                "Contacto" => new Contacto(),
                _ => new Sobre_Mi()
            };

            Detail = new NavigationPage(page);
        }
        
        // Cierra el menú lateral después de seleccionar una opción
        IsPresented = false;
    }
}