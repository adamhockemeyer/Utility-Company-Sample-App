using System;

using Utility.Helpers;
using Utility.Models;

namespace Utility.ViewModels
{
    public class AppointmentDetailsViewModel : PropertyChangedBase
    {

        string _technicianName;
        public string TechnicianName
        {
            get => _technicianName;
            set => SetProperty(ref _technicianName, value);
        }

        string _technicianPhone;
        public string TechnicianPhone
        {
            get => _technicianPhone;
            set => SetProperty(ref _technicianPhone, value);
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

        public AppointmentDetailsViewModel()
        {
        }

        public AppointmentDetailsViewModel(Appointment apt)
        {
            TechnicianName = apt.TechnicianName;
            TechnicianPhone = apt.TechnicianPhone;
            ServiceType = apt.AppointmentType;
            Date = apt.ScheduledTime;
            Time = new TimeSpan(apt.ScheduledTime.Hour, apt.ScheduledTime.Minute, apt.ScheduledTime.Second);
            Address1 = apt.Address1;
            Address2 = apt.Address2;
            City = apt.City;
            State = apt.State;
            Zip = apt.ZipCode;
        }
    }
}
