using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace grace;

public partial class ReportWindow : Window
{
    List<DateOnly> dates = new List<DateOnly>();
    bool isDaysSelected = true;
    public ReportWindow()
    {
        InitializeComponent(); 

    }
    
    private void Calendar_OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
    {
        dates = (sender as Calendar).SelectedDates.Select(d => DateOnly.FromDateTime(d)).ToList();
        Update();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if ((sender as RadioButton).Name == "ByDays")
            isDaysSelected = true;
        else
            isDaysSelected = false;
        Update();
    }

    public void Update()
    {
        if (isDaysSelected)
        {
            var alldates = Actions.DBContext.Orders.ToList().Where(o => dates.Contains(o.Startdate) == true).ToList();
            var q = (from x in alldates
                group x by x.Startdate
                into g
                let count = g.Count()
                orderby count descending
                select new { Value = g.Key, Count = count });
            ISeries[] Series =
            [
                new ColumnSeries<int>
                {
                    Values = q.OrderBy(s => s.Value).Select(s => s.Count).ToList(),
                    Fill = new SolidColorPaint(SKColors.Teal),
                    Padding = 0,
                    MaxBarWidth = double.MaxValue
                }
            ];
            MainChart.Series = Series;
            MainChart.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labels = q.OrderBy(s => s.Value).Select(s => s.Value.ToString()).ToList()
                }
            };
            Table.ItemsSource = q.OrderBy(s => s.Value);
        }
        else
        {
            var all = Actions.orderMaps.Where(o => dates.Contains(o.Order.Startdate) == true).ToList();
            var q = (from x in all
                group x by x.Services.Select(s => s.Serviceid)
                into g
                let count = g.Count()
                orderby count descending
                select new { Value = g.Key, Count = count });
            ISeries[] Series =
            [
                new ColumnSeries<int>
                {
                    Values = q.OrderBy(s => s.Value).Select(s => s.Count).ToList(),
                    Fill = new SolidColorPaint(SKColors.Teal),
                    Padding = 0,
                    MaxBarWidth = double.MaxValue
                }
            ];
            MainChart.Series = Series;
        }
    }
}