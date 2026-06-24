using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages;

public partial class PrincipalPage : ContentPage
{
    public PrincipalPage()
    {
        InitializeComponent();
    }

    private async void BtnRegresar_OnClicked(object? sender, EventArgs e)
    {
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new LoginPage();
        } 
    }
}