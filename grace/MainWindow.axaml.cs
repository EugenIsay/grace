using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace grace;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Orders.ItemsSource = Actions.orderMaps;
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        new MakeOrderWindow().Show();
        this.Close();
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        new AuthorizationWindow().Show();
        this.Close();
    }
}