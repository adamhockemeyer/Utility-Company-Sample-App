using System;
using System.Collections.ObjectModel;

using Utility.Helpers;
using Utility.Models;
using Utility.Pages;

namespace Utility.ViewModels
{
    public class MasterViewModel : PropertyChangedBase
    {
        MasterPageItem _selectedItem;
        public MasterPageItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        string _username;
        public string Username 
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        string _isLoggedIn;
        public string IsLoggedIn
        {
            get => _isLoggedIn;
            set => SetProperty(ref _isLoggedIn, value);
        }

        public ObservableCollection<MasterPageItem> MenuItems { get; set; }

        public MasterViewModel()
        {
            Username = "Guest";

            MenuItems = new ObservableCollection<MasterPageItem>();

            MenuItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconName = "fa-home",
                Active = true,
                TargetType = typeof(HomePage)
            });

            MenuItems.Add(new MasterPageItem{
                Title = "Account Summary",
                IconName = "fa-info-circle",
                Active = false,
                TargetType = typeof(AccountSummaryPage)
            });

            MenuItems.Add(new MasterPageItem
            {
                Title = "Payments",
                IconName = "fa-money",
                Active = false,
                TargetType = typeof(PaymentsPage)
            });

            MenuItems.Add(new MasterPageItem
            {
                Title = "Billing History",
                IconName = "fa-history",
                Active = false,
                TargetType = typeof(BillingPage)
            });

            MenuItems.Add(new MasterPageItem
            {
                Title = "Usage",
                IconName = "fa-bar-chart",
                Active = false,
                TargetType = typeof(UsagePage)
            });

            MenuItems.Add(new MasterPageItem
            {
                Title = "Appointments",
                IconName = "fa-wrench",
                Active = false,
                TargetType = typeof(ServiceAppointmentsPage)
            });

            MenuItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconName = "fa-cog",
                Active = false,
                TargetType = typeof(SettingsPage)
            });
        }
    }
}
