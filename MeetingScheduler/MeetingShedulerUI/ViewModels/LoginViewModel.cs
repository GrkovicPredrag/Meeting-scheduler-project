using MeetingShedulerUI.Commands;
using MeetingShedulerUI.Helpers;
using MeetingShedulerUI.Services;
using MeetingShedulerUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingShedulerUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginFormViewModel LoginFormViewModel { get; }

        public ICommand NavigateProfile { get; }

        public LoginViewModel(NavigationService<ProfileViewModel> profileNavigationService, LoginFormViewModel loginFormViewModel)
        {
            LoginFormViewModel = loginFormViewModel;
            LoginFormViewModel.UserLoggedIn += NavigateToProfile;

            NavigateProfile = new NavigateCommand<ProfileViewModel>(profileNavigationService);
        }

        private void NavigateToProfile(object sender, EventArgs e)
        {
            MessageBox.Show($"User {LoggedUser.Instance.User.Username} logged in");

            this.NavigateProfile.Execute(null);
        }
    }
}
