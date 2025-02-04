using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using grace.Models;

namespace grace;

public partial class MakeOrderWindow : Window
{
    List<Service> Services = Actions.DBContext.Services.ToList();
    ObservableCollection<string> names = new ObservableCollection<string>(Actions.DBContext.Services.Select(s => s.Title).ToList());
    ObservableCollection<Service> SelectedServices = new ObservableCollection<Service>();


    public MakeOrderWindow()
    {
        InitializeComponent();
        Client.ItemsSource = Actions.Clients.Select(c => c.FullName);
        Service.ItemsSource = names;
        ServicesBox.ItemsSource = SelectedServices;
        OrderId.ItemsSource = (Actions.DBContext.Orders.OrderBy(o => o.Id).Last().Id + 1).ToString();
    }

    private void AddService_OnClick(object? sender, RoutedEventArgs e)
    {
        new AddClient().ShowDialog(this);
        Actions.UpdateClient();
        Client.ItemsSource = Actions.Clients.Select(c => c.FullName);
    }

    private void Service_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if ((sender as AutoCompleteBox).SelectedItem == null)
            return;
        string selected = (sender as AutoCompleteBox).SelectedItem.ToString();
        (sender as AutoCompleteBox).IsDropDownOpen = false;
        names.Remove(selected);
        SelectedServices.Add(Services.FirstOrDefault(s => s.Title == selected));
        Cost.Text = SelectedServices.Select(s => s.Costperhour).Sum().ToString();

    }

    private void Delete(object? sender, RoutedEventArgs e)
    {
        int id = int.Parse((sender as Button).Tag.ToString());
        names.Add(Services.FirstOrDefault(s => s.Id == id).Title);
        SelectedServices.Remove(Services.FirstOrDefault(s => s.Id == id));
        Cost.Text = SelectedServices.Select(s => s.Costperhour).Sum().ToString();
    }

    private void OrderId_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        OrderId.IsDropDownOpen = true;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Client.SelectedItem.ToString()) || string.IsNullOrEmpty(OrderId.Text) || SelectedServices.Count == 0)
        {
            return;
        }
        Actions.DBContext.Orders.Add(new Order()
        {
            Startdate = DateOnly.FromDateTime(DateTime.Now),
            Starttime = TimeOnly.FromDateTime(DateTime.Now),
            User = Actions.DBContext.Users.FirstOrDefault(u => u.FullName == Client.SelectedItem.ToString()),
            Id = int.Parse(OrderId.Text),
            Statusid = 1
        });
        foreach (Service service in SelectedServices)
        {
            Actions.DBContext.Orderservices.Add(new Orderservice() { Orderid = int.Parse(OrderId.Text), Serviceid = service.Id });
        }
        Actions.DBContext.SaveChanges();
        new MainWindow().Show();
        this.Close();
    }
}