using MeetingShedulerUI.Commands;
using MeetingShedulerUI.Helpers;
using MeetingShedulerUI.Models;
using MeetingShedulerUI.Services;
using MeetingShedulerUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingShedulerUI.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        #region fields 
        private string username;
        private string email;
        private string team;
        #endregion

        #region props
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ICommand NavigateHome { get; }
        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                OnPropertyChanged();
            }
        }

        public string Team
        {
            get { return this.team; }
            set
            {
                this.team = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ProfileViewModel(NavigationService<HomeViewModel> homeNavigationService, NavigationBarViewModel navigationBarViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            NavigationBarViewModel.SetVisibilityOfButtons();
            NavigateHome = new NavigateCommand<HomeViewModel>
                (homeNavigationService);

            FillProfileInfo();
        }


        private void FillProfileInfo()
        {
            UserModel loggedUser = LoggedUser.Instance.User;

            if (loggedUser == null)
            {
                Username = String.Empty;
                Email = String.Empty;
                Team = String.Empty;
                return;
            }

            Username = LoggedUser.Instance.User.Username;
            Email = LoggedUser.Instance.User.Email;
            Team = LoggedUser.Instance.User.Team.Name;
        }
    }
}
