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
    public class ServiceAppointmentsViewModel : PropertyChangedBase
    {
        ObservableCollection<Appointment> _appointmentHistory;
        public ObservableCollection<Appointment> AppointmentHistory
        {
            get => _appointmentHistory;
            set => SetProperty(ref _appointmentHistory, value);
        }

        ObservableCollection<string> _serviceTypes;
        public ObservableCollection<string> ServiceTypes
        {
            get => _serviceTypes;
            set => SetProperty(ref _serviceTypes, value);
        }

        Appointment _selectedItem;
        public Appointment SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);

                if (_selectedItem == null)
                    return;

                ViewAppointmentDetailCommand?.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        ICommand _fetchAppointmentHistoryCommand;
        public ICommand FetchAppointmentHistoryCommand
        {
            get => _fetchAppointmentHistoryCommand;
            set => SetProperty(ref _fetchAppointmentHistoryCommand, value);
        }

        ICommand _viewAppointmentDetailCommand;
        public ICommand ViewAppointmentDetailCommand
        {
            get => _viewAppointmentDetailCommand;
            set => SetProperty(ref _viewAppointmentDetailCommand, value);
        }

        ICommand _scheduleServiceCommand;
        public ICommand ScheduleServiceCommand
        {
            get => _scheduleServiceCommand;
            set => SetProperty(ref _scheduleServiceCommand, value);
        }

        string _serviceType;
        public string ServiceType
        {
            get => _serviceType;
            set => SetProperty(ref _serviceType, value);
        }

        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        string _address1;
        public string Address1
        {
            get => _address1;
            set => SetProperty(ref _address1, value);
        }

        string _address2;
        public string Address2
        {
            get => _address2;
            set => SetProperty(ref _address2, value);
        }

        string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        string _state;
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        string _zip;
        public string Zip
        {
            get => _zip;
            set => SetProperty(ref _zip, value);
        }


        public ServiceAppointmentsViewModel()
        {
            InitProperties();

            InitCommands();

            FetchAppointmentHistoryCommand?.Execute(null);
        }

        void InitProperties()
        {
            ServiceTypes = new ObservableCollection<string>(new List<string>
            {
                "Start Service",
                "Stop Service",
                "Transfer Service",
                "Inspect"
            });

            Address1 = "21234 Main StL";
            City = "CAVE CREEK";
            State = "AZ";
            Zip = "85331-0007";

            Date = DateTime.Now.AddDays(7);
            Time = TimeSpan.FromHours(11);
        }

        void InitCommands()
        {
            FetchAppointmentHistoryCommand = new Command(async () => await FetchAppointmentHistoryAsync());
            ViewAppointmentDetailCommand = new Command<Appointment>(async (apt) => await ViewAppointmentDetailsPageAsync(apt));
            ScheduleServiceCommand = new Command(async () => await ScheduleServiceAsync());
        }

        async Task FetchAppointmentHistoryAsync()
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

            // Fake network call
            await Task.Delay(700);

            AppointmentHistory = new ObservableCollection<Appointment>(new List<Appointment>
            {
                new Appointment { Address1 = "21234 Main St", City = "CAVE CREEK", State = "AZ", ZipCode = "85331-0007", AppointmentType = "Start Service", Status = "Dispatched", ScheduledTime = new DateTime(2018,2,6,11,0,0), TechnicianName = "John Smith", TechnicianPhone = "(415) 123-4567" }
            });

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }

        async Task ViewAppointmentDetailsPageAsync(Appointment apt)
        {
            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new AppointmentDetailsPage(apt));
        }

        async Task ScheduleServiceAsync()
        {
            var confirmed = await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync("Are you sure you want to schedule your service?", "Appointment Confirmation", "Schedule");

            if(confirmed)
            {
                if(ServiceType != null && Date != null && Time != null && Address1 != null && City != null && State != null && Zip != null)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Scheduling...");

                    await Task.Delay(700);

                    Appointment apt = new Appointment
                    {
                        Address1 = Address1,
                        Address2 = Address2,
                        City = City,
                        State = State,
                        ZipCode = Zip,
                        AppointmentType = ServiceType,
                        ScheduledTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds),
                        Status = "Pending"                         
                    };

                    AppointmentHistory.Add(apt);

                    ServiceType = null;

                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("One or more of the fields are missing values.", "Incomplete Appointment");
                }
            }
        }
    }
}
