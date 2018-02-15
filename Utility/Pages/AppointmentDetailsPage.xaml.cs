using System;
using System.Collections.Generic;
using Utility.Models;
using Utility.ViewModels;
using Xamarin.Forms;

namespace Utility.Pages
{
    public partial class AppointmentDetailsPage : ContentPage
    {
        public AppointmentDetailsViewModel ViewModel { get; set; }

        public AppointmentDetailsPage() : this(new Appointment())
        {
           
        }

        public AppointmentDetailsPage(Appointment apt)
        {
            InitializeComponent();

            BindingContext = ViewModel ?? new AppointmentDetailsViewModel(apt);
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
