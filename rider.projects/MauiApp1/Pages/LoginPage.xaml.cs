using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1.Pages;

public partial class LoginPage : ContentPage
{
    public string nombreUsuario { get; set; }
    public string contra { get; set; }
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void BtnIngresar_OnClicked(object sender, EventArgs e)
    {
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new PrincipalPage();
        } 
    }
    
    /*
    private void BtnIngresar_OnClicked(object? sender, EventArgs e)
    {
        DisplayAlert("Alerta", "Di click", "Salir");
    }
    */
    
    private void BtnInfo_OnClicked(object? sender, EventArgs e)
    {
        DisplayAlert("Alerta", "Usuario:" + nombreUsuario + " - "  + "Contraseña:" + contra, "Cerrar");
    }
}