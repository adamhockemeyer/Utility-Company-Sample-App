using System;
using System.Collections.Generic;
using Utility.ViewModels;
using Xamarin.Forms;

namespace Utility.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel ViewModel { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = ViewModel ?? new SettingsViewModel();

            NavigationPage.SetTitleIcon(this, "smallLogo.png");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            scrollView.Scrolled += ScrollView_Scrolled;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            scrollView.Scrolled -= ScrollView_Scrolled;
        }

        void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                double offset = headerContent.Height;

                headerContent.Opacity = (offset - e.ScrollY) / offset;
            });
        }
    }
}
