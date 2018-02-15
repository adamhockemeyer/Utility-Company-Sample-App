using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Utility.Models;

namespace Utility.Pages
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            SetNavigationBarColors();

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                masterPage.UnsetActive();

                item.Active = true;

                Page page = (Page)Activator.CreateInstance(item.TargetType);

                Detail = new NavigationPage(page);

                SetNavigationBarColors();
            }

            masterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }

        void SetNavigationBarColors()
        {

            Device.BeginInvokeOnMainThread(() => {

                var mp = Application.Current.MainPage as MasterDetailPage;
                var np = (NavigationPage)mp.Detail;

                np.BarBackgroundColor = Color.White;
                np.BarTextColor = (Color)Application.Current.Resources["brandOrange"];
            });
        }
    }
}

