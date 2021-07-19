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
    public class HomeViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateLogin { get; }

        public HomeViewModel(NavigationService<LoginViewModel> loginNavigationService, NavigationBarViewModel navigationBarViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateLogin = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
