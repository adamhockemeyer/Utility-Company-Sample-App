using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Utility.Helpers;
using Xamarin.Forms;

namespace Utility.ViewModels
{
    public class PayMyBillViewModel : PropertyChangedBase
    {
        public ObservableCollection<string> BankAccounts { get; set; }
        public ObservableCollection<string> AccountTypes { get; set; }

        ICommand _continueCommand;
        public ICommand ContinueCommand
        {
            get => _continueCommand;
            set => SetProperty(ref _continueCommand, value);
        }


        public PayMyBillViewModel()
        {
            InitProperties();
            InitCommands();
           
        }

        void InitProperties()
        {
            BankAccounts = new ObservableCollection<string>(new List<string>()
            {
                "Add New",
                "*****0068 - Checking"
            });

            AccountTypes = new ObservableCollection<string>(new List<string>()
            {
                "Checking",
                "Savings"
            });
        }

        void InitCommands()
        {
            ContinueCommand = new Command(async () =>
            {
                var result = await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync(new Acr.UserDialogs.ConfirmConfig(){ OkText = "Yes, Make Payment", CancelText = "Cancel", Title = "Payment Confirmation", Message = "Are you sure you want to pay $95.70 on 1/29/18?"});

                if(result)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Making Payment");

                    await Task.Delay(700);

                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }
            });
        }
    }
}
