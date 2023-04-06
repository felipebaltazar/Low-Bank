using LowBank_Mobile.ViewModels;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;

namespace LowBank_Mobile;

public partial class MainPage : ContentPage
{
    public static BindableProperty LoginErrorProperty =
        BindableProperty.Create(
            nameof(LoginError),
            typeof(bool),
            typeof(MainPage));

    public bool LoginError
    {
        get
        {
            return (bool)GetValue(LoginErrorProperty);
        }
        set
        {
            SetValue(LoginErrorProperty, value);
        }
    }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();

        this.SetBinding(LoginErrorProperty, "LoginError");
    }

    protected override void OnDisappearing()
    {
        loginEntry.Unfocus();
        passwordEntry.Unfocus();
        base.OnDisappearing();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(LoginError))
        {
            if (LoginError == true)
            {
                DisplayLoginError();
            }
        }
    }

    public async void DisplayLoginError()
    {
        await this.DisplayAlert("Autenticação", "Credenciais inválidas", "Entendi!");
    }
}

