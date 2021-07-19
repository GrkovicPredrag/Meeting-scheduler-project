using MeetingShedulerUI.Commands;
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
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateProfileCommand { get; }

        public NavigationBarViewModel(NavigationService<HomeViewModel> homeNavigationService, 
            NavigationService<LoginViewModel> loginNavigationService,
            NavigationService<ProfileViewModel> profileNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            NavigateProfileCommand = new NavigateCommand<ProfileViewModel>(profileNavigationService);                
        }
    }
}
