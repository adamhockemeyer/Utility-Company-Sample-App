using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using Utility.Helpers;
using Utility.Pages;

namespace Utility.ViewModels
{
    public class AccountSummaryViewModel : PropertyChangedBase
    {
        
        #region Properties
        decimal _amountDue;
        public decimal AmountDue
        {
            get => _amountDue;
            set => SetProperty(ref _amountDue, value);
        }

        DateTime _paymentDueBy;
        public DateTime PaymentDueBy
        {
            get => _paymentDueBy;
            set => SetProperty(ref _paymentDueBy, value);
        }

        decimal _lastPaymentAmount;
        public decimal LastPaymentAmount
        {
            get => _lastPaymentAmount;
            set => SetProperty(ref _lastPaymentAmount, value);
        }

        DateTime _lastPaymentDate;
        public DateTime LastPaymentDate
        {
            get => _lastPaymentDate;
            set => SetProperty(ref _lastPaymentDate, value);
        }
        #endregion

        #region Commands

        ICommand _getAccountSummaryDetailsCommand;
        ICommand GetAccountSummaryDetailsCommand
        {
            get => _getAccountSummaryDetailsCommand;
            set => SetProperty(ref _getAccountSummaryDetailsCommand, value);
        }

        ICommand _navigateToPayMyBillCommand;
        public ICommand NavigateToPayMyBillCommand
        {
            get => _navigateToPayMyBillCommand;
            set => SetProperty(ref _navigateToPayMyBillCommand, value);
        }

        #endregion

        public AccountSummaryViewModel()
        {
            InitCommands();

            GetAccountSummaryDetailsCommand?.Execute(null);
        }

        void InitCommands()
        {
            GetAccountSummaryDetailsCommand = new Command(async () => await GetAccountDetailsAsync());

            NavigateToPayMyBillCommand = new Command(async () => await NavigateToPayMyBillPageAsync());
        }

        async Task GetAccountDetailsAsync()
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            // Fake network call
            await Task.Delay(700);

            AmountDue = 95.70m;
            PaymentDueBy = new DateTime(2018, 2, 12);
            LastPaymentDate = new DateTime(2018, 12, 29);
            LastPaymentAmount = 41.85m;

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }

        async Task NavigateToPayMyBillPageAsync()
        {
            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new PayMyBillPage());
        }
    }
}
