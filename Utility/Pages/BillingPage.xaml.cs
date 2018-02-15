using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.ViewModels;

namespace Utility.Pages
{
    public partial class BillingPage : ContentPage
    {
        public BillingViewModel ViewModel { get; set; }

        public BillingPage()
        {
            InitializeComponent();

            NavigationPage.SetTitleIcon(this, "smallLogo.png");

            BindingContext = ViewModel ?? new BillingViewModel();
        }
    }
}
