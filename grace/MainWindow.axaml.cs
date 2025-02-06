using System;
using System.Linq;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace grace;

public partial class MainWindow : Window
{
    DispatcherTimer dispatcherTimer;
    TimeSpan time;
    public MainWindow()
    {
        InitializeComponent();
        Orders.ItemsSource = Actions.orderMaps;
        StartTimer();
    }

    public async void StartTimer()
    {
        time = TimeSpan.FromMinutes(90);
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        dispatcherTimer.Tick += DispatcherTimer_Tick;
        dispatcherTimer.Start();

    }
    private void DispatcherTimer_Tick(object sender, EventArgs e)
    {
        if (time == TimeSpan.Zero)
        {
            dispatcherTimer.Stop();
            new AuthorizationWindow().Show();
            this.Close();
        }
        else
        {
            time = time.Add(TimeSpan.FromSeconds(-1));
            Time.Text = time.ToString("c");

        }
    }
    
    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        new MakeOrderWindow().ShowDialog(this);
        Actions.UpdateOrder();
        Orders.ItemsSource = Actions.orderMaps;
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        new AuthorizationWindow().Show();
        this.Close();
    }
}