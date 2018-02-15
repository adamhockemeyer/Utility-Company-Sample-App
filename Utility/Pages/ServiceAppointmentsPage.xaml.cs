using System;
using System.Collections.Generic;
using Utility.ViewModels;
using Xamarin.Forms;

namespace Utility.Pages
{
    public partial class ServiceAppointmentsPage : ContentPage
    {
        public ServiceAppointmentsViewModel ViewModel { get; set; }

        public ServiceAppointmentsPage()
        {
            InitializeComponent();

            NavigationPage.SetTitleIcon(this, "smallLogo.png");

            BindingContext = ViewModel ?? new ServiceAppointmentsViewModel();
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
