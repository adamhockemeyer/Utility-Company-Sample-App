using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using Utility.Helpers;

namespace Utility.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get => _updateCommand;
            set => SetProperty(ref _updateCommand, value);
        }

        public SettingsViewModel()
        {
            InitCommands();
        }

        void InitCommands()
        {
            UpdateCommand = new Command(async () => await UpdateAsync());
        }

        async Task UpdateAsync()
        {
            var result = await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync("Are you sure you want to make changes to your account?", "Confirm", "Yes");

            if(result)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

                await Task.Delay(700);

                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }
        }
    }
}
