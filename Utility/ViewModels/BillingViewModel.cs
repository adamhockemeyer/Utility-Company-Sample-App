using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using Utility.Helpers;
using Utility.Models;
using Utility.Pages;

namespace Utility.ViewModels
{
    public class BillingViewModel : PropertyChangedBase
    {
        ObservableCollection<BillingHistory> _billingHistory;
        public ObservableCollection<BillingHistory> BillingHistory
        {
            get => _billingHistory;
            set => SetProperty(ref _billingHistory, value);
        }

        ICommand _fetchBillingHistoryCommand;
        public ICommand FetchBillingHistoryCommand
        {
            get => _fetchBillingHistoryCommand;
            set => SetProperty(ref _fetchBillingHistoryCommand, value);
        }

        ICommand _viewBillCommand;
        public ICommand ViewBillCommand
        {
            get => _viewBillCommand;
            set => SetProperty(ref _viewBillCommand, value);
        }

        BillingHistory _selectedItem;
        public BillingHistory SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);

                if (_selectedItem == null)
                    return;

                ViewBillCommand?.Execute(_selectedItem);

                SelectedItem = null;
            }
        }


        public BillingViewModel()
        {
            InitCommands();

            FetchBillingHistoryCommand?.Execute(null);
        }

        void InitCommands()
        {
            FetchBillingHistoryCommand = new Command(async () => await GetBillingHistoryAsync());
            ViewBillCommand = new Command<BillingHistory>(async (bill) => await ViewBillPDF(bill));
        }

        async Task GetBillingHistoryAsync()
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            // Fake network call
            await Task.Delay(700);

            Device.BeginInvokeOnMainThread(() =>
            {

                BillingHistory = new ObservableCollection<Models.BillingHistory>(new List<BillingHistory>()
                {
                    new BillingHistory { Date = new DateTime(2018,01,24), Amount = 95.70m },
                    new BillingHistory { Date = new DateTime(2017,12,20), Amount = 41.85m },
                    new BillingHistory { Date = new DateTime(2017,11,21), Amount = 27.01m },
                    new BillingHistory { Date = new DateTime(2017,10,20), Amount = 20.17m },
                    new BillingHistory { Date = new DateTime(2017,9,21), Amount = 17.38m },
                    new BillingHistory { Date = new DateTime(2017,8,22), Amount = 17.37m },
                    new BillingHistory { Date = new DateTime(2017,7,24), Amount = 17.35m },
                    new BillingHistory { Date = new DateTime(2017,6,22), Amount = 18.56m },
                    new BillingHistory { Date = new DateTime(2017,5,24), Amount = 41.63m },
                    new BillingHistory { Date = new DateTime(2017,5,16), Amount = 80.00m },
                });
            });

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }

        async Task ViewBillPDF(BillingHistory bill)
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            // Fake network call
            await Task.Delay(700);

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();

            // Note: ViewPDFPage currently uses an embedded pdf in each platform specific project for demo purposes.
            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new ViewPDFPage() { Title = $"{bill.Date.ToString("d")} - Bill"} );
        }
    }
}
