using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.ViewModels;
using System.Linq;

namespace Utility.Pages
{
    public partial class MasterPage : ContentPage
    {
        public MasterViewModel ViewModel { get; set; }

        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            ViewModel = ViewModel ?? new MasterViewModel();

            this.BindingContext = ViewModel;

        }

        public void UnsetActive()
        {
            foreach(var active in ViewModel.MenuItems.Where(p => p.Active))
            {
                active.Active = false;
            }
        }
    }
}
