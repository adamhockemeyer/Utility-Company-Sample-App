using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.ViewModels;

namespace Utility.Pages
{
    public partial class AccountSummaryPage : ContentPage
    {
        public AccountSummaryViewModel ViewModel { get; set; }

        public AccountSummaryPage()
        {
            InitializeComponent();

            BindingContext = ViewModel ?? new AccountSummaryViewModel();
        }
    }
}
