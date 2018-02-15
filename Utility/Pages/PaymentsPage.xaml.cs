using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.ViewModels;

namespace Utility.Pages
{
    public partial class PaymentsPage : ContentPage
    {
        public PaymentsViewModel ViewModel { get; set; }

        public PaymentsPage()
        {
            InitializeComponent();

            NavigationPage.SetTitleIcon(this, "smallLogo.png");

            BindingContext = ViewModel ?? new PaymentsViewModel();
        }

    }
}
