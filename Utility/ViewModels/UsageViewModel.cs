using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Utility.Helpers;
using Utility.Models;

namespace Utility.ViewModels
{
    public class UsageViewModel : PropertyChangedBase
    {
        ObservableCollection<GasUsage> _gasUsage;

        public ObservableCollection<GasUsage> GasUsage
        {
            get => _gasUsage;
            set => SetProperty(ref _gasUsage, value);
        }

        string _dateRanges;
        public string DateRanges
        {
            get => _dateRanges;
            set => SetProperty(ref _dateRanges, value);
        }

        public UsageViewModel()
        {
            GasUsage = new ObservableCollection<GasUsage>(new List<GasUsage>
            {
                new GasUsage { Date = new DateTime(2017,1,1), Value = 0f},
                new GasUsage { Date = new DateTime(2017,2,1), Value = 0f},
                new GasUsage { Date = new DateTime(2017,3,1), Value = 0f},
                new GasUsage { Date = new DateTime(2017,4,1), Value = 0f},
                new GasUsage { Date = new DateTime(2017,5,1), Value = 2f},
                new GasUsage { Date = new DateTime(2017,6,1), Value = 5f},
                new GasUsage { Date = new DateTime(2017,7,1), Value = 4f},
                new GasUsage { Date = new DateTime(2017,8,1), Value = 4f},
                new GasUsage { Date = new DateTime(2017,9,1), Value = 4f},
                new GasUsage { Date = new DateTime(2017,10,1), Value = 6f},
                new GasUsage { Date = new DateTime(2017,11,1), Value = 11f},
                new GasUsage { Date = new DateTime(2017,12,1), Value = 22f},
                new GasUsage { Date = new DateTime(2018,1,1), Value = 62f}
            });

            DateRanges = $"{GasUsage[0].Date.ToString("d")} - {GasUsage[GasUsage.Count - 1].Date.ToString("d")}";
        }
    }
}
