using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using grace.Models;

namespace grace;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
    }

    private void Ready_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Actions.IsUser(new User() { Email = Email.Text, Password = Password.Text }))
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}