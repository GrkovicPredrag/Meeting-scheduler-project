using System;
using System.Windows;
using MeetingShedulerUI.Services;
using MeetingShedulerUI.Stores;
using MeetingShedulerUI.ViewModels;

namespace MeetingShedulerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;
        private readonly LoginFormViewModel _loginFormViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _loginFormViewModel = new LoginFormViewModel();
            _navigationBarViewModel = new NavigationBarViewModel
                (CreateHomeNavigationService(), CreateLoginNavigationService(), CreateProfileNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            var navHome = CreateProfileNavigationService();
            navHome.Navigate();
           

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>
                (_navigationStore, () => new HomeViewModel(CreateLoginNavigationService(), _navigationBarViewModel));
        }

        private NavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>
                (_navigationStore, () => new LoginViewModel(CreateProfileNavigationService(), _loginFormViewModel));
        }

        private NavigationService<ProfileViewModel> CreateProfileNavigationService()
        {
            return new NavigationService<ProfileViewModel>
                (_navigationStore, () => new ProfileViewModel(CreateHomeNavigationService(), _navigationBarViewModel));
        }
    }
}
