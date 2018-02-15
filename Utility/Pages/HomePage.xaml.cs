using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Utility.ViewModels;

namespace Utility.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomeViewModel ViewModel { get; set; }

        public HomePage()
        {
            InitializeComponent();

            // Using an image for the Home Page
            NavigationPage.SetTitleIcon(this, "smallLogo.png");

            BindingContext = ViewModel ?? new HomeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitAnimations();
        }

        async Task InitAnimations()
        {
            bannerTextPrimary.TranslationX = Width;
            bannerTextSecondary.Opacity = 0;

            await Task.Delay(1000);

            await bannerTextPrimary.TranslateTo(0,0,1000, Easing.SpringOut);
            await bannerTextSecondary.FadeTo(1, 500);

        }

    }
}
