using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.ViewModels;
using Utility.Extensions;

using SkiaSharp;
using Microcharts;
using System.Threading.Tasks;

namespace Utility.Pages
{
    public partial class UsagePage : ContentPage
    {
        public UsageViewModel ViewModel { get; set; }

        public UsagePage()
        {
            InitializeComponent();

            NavigationPage.SetTitleIcon(this, "smallLogo.png");

            BindingContext = ViewModel ?? new UsageViewModel();

            InitAnimations();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitChart();
        }

        async Task InitChart()
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            await Task.Delay(700);

            List<Microcharts.Entry> entries = new List<Microcharts.Entry>();

            Color color = (Color)Application.Current.Resources["brandBlue"];

            //SKColor barColor = SKColor.FromHsl((float)color.Hue / 255, (float)color.Saturation / 255, (float)color.Luminosity / 255, (byte)color.A);
            SKColor barColor;
            SKColor.TryParse(color.GetHexString(), out barColor);

            ViewModel = ViewModel ?? new UsageViewModel();

            foreach (var usage in ViewModel.GasUsage)
            {
                entries.Add(new Microcharts.Entry(usage.Value) { Color = barColor, Label = usage.Date.ToString("MMMM").Substring(0, 1), ValueLabel = usage.Value.ToString() });
            }

            var chart = new BarChart() { Entries = entries };


            this.usageChart.Chart = chart;

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }

        async Task InitAnimations()
        {
            scrollShower.Opacity = 0;

            await Task.Delay(1500);

            await scrollShower.FadeTo(1);

            scrollShower.TranslateTo(-100, 0, 350);

            Device.BeginInvokeOnMainThread(async () => {
                
                await scrollView.ScrollToAsync(100, 0, true);
            });


            await Task.Delay(750);

            scrollShower.TranslateTo(0, 0, 350);


            Device.BeginInvokeOnMainThread(async () => {
                await scrollView.ScrollToAsync(0, 0, true);
                await scrollShower.FadeTo(0);
            });

            

        }
    }
}
