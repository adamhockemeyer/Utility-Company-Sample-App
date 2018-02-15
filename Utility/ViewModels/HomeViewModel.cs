using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Utility.Helpers;
using Xamarin.Forms;

namespace Utility.ViewModels
{
    public class HomeViewModel : PropertyChangedBase
    {
        ICommand _callCommand;
        public ICommand CallCommand
        {
            get => _callCommand;
            set => SetProperty(ref _callCommand, value);
        }

        ICommand _navigateCommand;
        public ICommand NavigateCommand
        {
            get => _navigateCommand;
            set => SetProperty(ref _navigateCommand, value);
        }

        public HomeViewModel()
        {
            InitCommands();
        }

        void InitCommands()
        {
            CallCommand = new Command<string>(async (phoneNumber) => await CallAsync(phoneNumber));
            NavigateCommand = new Command<string>(async (page) => await NavigatePageAsync(page));
        }

        async Task CallAsync(string phoneNumber, bool confirmFirst = true)
        {
            bool doMakeCall = true;

            if(confirmFirst)
            {
                doMakeCall = await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync($"Are you sure you want to call {phoneNumber}?",okText: "Call");
            }

            if(doMakeCall && Plugin.Messaging.CrossMessaging.Current.PhoneDialer.CanMakePhoneCall)
            {
                Plugin.Messaging.CrossMessaging.Current.PhoneDialer.MakePhoneCall(phoneNumber,phoneNumber.Equals("911") ? "911" : "Soutwest Gas");
            }
        }

        async Task NavigatePageAsync(string page)
        {
            Type type = Type.GetType("Utility.Pages." + page);
            Page p = (Page)Activator.CreateInstance(type);

            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(p);
        }
    }
}
