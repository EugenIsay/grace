using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace grace;

public partial class AddClient : Window
{
    public AddClient()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Surname.Text) 
            || BDay.SelectedDate == null || string.IsNullOrEmpty(PSeries.Text) ||  string.IsNullOrEmpty(PNumber.Text) 
            || string.IsNullOrEmpty(Addres.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
        {
            return;
        }
        Actions.DBContext.Users.Add(new Models.User() { Name = Name.Text, Surname = Surname.Text, 
            Patronimic = Patronim.Text, Address = Addres.Text, Birthday = DateOnly.FromDateTime(BDay.SelectedDate.Value.Date), 
            Code = int.Parse(Code.Text), Email = Email.Text, Password = Password.Text, 
            Pasportnumber = int.Parse(PNumber.Text), Pasportseries = int.Parse(PSeries.Text), Roleid = 4
        });
        Actions.DBContext.SaveChanges();
        this.Close();
    }
}