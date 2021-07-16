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
        public ICommand NavigateLogin { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateLogin = new NavigateCommand<LoginViewModel>
                (new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
        }
    }
}
