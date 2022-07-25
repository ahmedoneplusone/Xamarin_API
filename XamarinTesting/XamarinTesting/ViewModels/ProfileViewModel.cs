using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinTesting.Models;
using XamarinTesting.Services;

namespace XamarinTesting.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Profile> Profiles { get; set; }
        public Profile CurrentUser { get; set; }
        public ProfileService pService;
        public AsyncCommand RefreshCommand { get; set; }

         public ProfileViewModel()
        {
            Title = "Employees";

            pService = new ProfileService();
            Profiles = new ObservableRangeCollection<Profile>();
            var profilesList = (List<Profile>)pService.GetProfiles();
            CurrentUser = profilesList.Find(x => x.ProfileID == 1);
            profilesList.Remove(CurrentUser);
            Profiles.AddRange(profilesList);
            CurrentUser = pService.GetProfileByID(1);

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
