using System;
using Utility.Helpers;

namespace Utility.Models
{
    public class MasterPageItem : PropertyChangedBase
    {

        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        string _iconName;
        public string IconName
        {
            get => _iconName;
            set => SetProperty(ref _iconName, value);
        }

        bool _active;
        public bool Active 
        {
            get => _active;
            set => SetProperty(ref _active, value);
        }

        Type _targetType;
        public Type TargetType
        {
            get => _targetType;
            set => SetProperty(ref _targetType, value);
        }

    }
}
