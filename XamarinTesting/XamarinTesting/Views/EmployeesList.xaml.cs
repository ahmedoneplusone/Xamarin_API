using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTesting.Models;

namespace XamarinTesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesList : ContentPage
    {
        public EmployeesList()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var profile = ((ListView)sender).SelectedItem as Profile;
            if (profile == null)
                return;
            await DisplayAlert("Profile selected", profile.Name, "OK");
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

    }
}