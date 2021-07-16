using MeetingShedulerUI.Commands;
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
        public ICommand NavigateHome { get; }

        public ProfileViewModel(NavigationStore navigationStore)
        {
            NavigateHome = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }
    }
}
