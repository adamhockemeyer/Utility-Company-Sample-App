using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Utility.Helpers;
using Utility.Models;
using Xamarin.Forms;

namespace Utility.ViewModels
{
    public class PaymentsViewModel : PropertyChangedBase
    {
        ObservableCollection<PaymentHistory> _paymentHistory;
        public ObservableCollection<PaymentHistory> PaymentHistory
        {
            get => _paymentHistory;
            set => SetProperty(ref _paymentHistory, value);
        }

        ICommand _fetchPaymentHistoryCommand;
        public ICommand FetchPaymentHistoryCommand
        {
            get => _fetchPaymentHistoryCommand;
            set => SetProperty(ref _fetchPaymentHistoryCommand, value);
        }


        public PaymentsViewModel()
        {
            InitCommands();

            FetchPaymentHistoryCommand?.Execute(null);
        }


        void InitCommands()
        {
            FetchPaymentHistoryCommand = new Command(async () => await GetPaymentHistoryAsync());
        }

        async Task GetPaymentHistoryAsync()
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            // Fake network call
            await Task.Delay(700);

            Device.BeginInvokeOnMainThread(() => {

                PaymentHistory = new ObservableCollection<PaymentHistory>(new List<PaymentHistory>()
            {
                new PaymentHistory { Amount = 41.85m, Date = new DateTime(2017,12,29), Status = "Processed"},
                new PaymentHistory { Amount = 27.01m, Date = new DateTime(2017,11,30), Status = "Processed"},
                new PaymentHistory { Amount = 20.17m, Date = new DateTime(2017,10,31), Status = "Processed"},
                new PaymentHistory { Amount = 17.38m, Date = new DateTime(2017,9,29), Status = "Processed"},
                new PaymentHistory { Amount = 17.37m, Date = new DateTime(2017,8,31), Status = "Processed"},
                new PaymentHistory { Amount = 17.25m, Date = new DateTime(2017,7,31), Status = "Processed"},
                new PaymentHistory { Amount = 18.56m, Date = new DateTime(2017,6,30), Status = "Processed"},
                new PaymentHistory { Amount = 41.63m, Date = new DateTime(2017,5,31), Status = "Processed"}
            });
            });




            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }
    }

}
