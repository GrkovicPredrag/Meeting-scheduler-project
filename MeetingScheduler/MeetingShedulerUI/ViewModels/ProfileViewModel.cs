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
    public class ProfileViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateHome { get; }

        public ProfileViewModel(NavigationService<HomeViewModel> homeNavigationService, NavigationBarViewModel navigationBarViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateHome = new NavigateCommand<HomeViewModel>
                (homeNavigationService);
        }
    }
}
