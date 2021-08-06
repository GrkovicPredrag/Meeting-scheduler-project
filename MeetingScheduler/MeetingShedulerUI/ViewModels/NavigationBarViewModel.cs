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
using System.Windows;
using System.Windows.Input;

namespace MeetingShedulerUI.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private Visibility logoutVisible;
        private Visibility loginVisible;

        public Visibility LogoutVisible
        {
            get { return this.logoutVisible; }
            set
            {
                this.logoutVisible = value;
                OnPropertyChanged("LogoutVisible");
            }
        }

        public Visibility LoginVisible
        {
            get { return this.loginVisible; }
            set
            {
                this.loginVisible = value;
                OnPropertyChanged("LoginVisible");
            }
        }

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand LogoutCommand { get; }

        public NavigationBarViewModel(NavigationService<HomeViewModel> homeNavigationService, 
            NavigationService<LoginViewModel> loginNavigationService,
            NavigationService<ProfileViewModel> profileNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            NavigateProfileCommand = new NavigateCommand<ProfileViewModel>(profileNavigationService);
            LogoutCommand = new LogoutCommand(this);

            SetVisibilityOfButtons();
        }

        public void Logout()
        {
            LoggedUser.Instance.User = null;
            this.NavigateHomeCommand.Execute(EventArgs.Empty);
        }

        public void SetVisibilityOfButtons()
        {
            UserModel loggedUser = LoggedUser.Instance.User;

            if (loggedUser == null)
            {
                logoutVisible = Visibility.Hidden;
                loginVisible = Visibility.Visible;
                return;
            }

            logoutVisible = Visibility.Visible;
            loginVisible = Visibility.Hidden;
        }

    }
}
