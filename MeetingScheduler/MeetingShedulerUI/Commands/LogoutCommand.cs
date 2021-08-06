using Logger;
using MeetingShedulerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly ILogger _logger;
        public NavigationBarViewModel ViewModel { get; set; }

        public LogoutCommand()
        {

        }

        public LogoutCommand(NavigationBarViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            this.ViewModel.Logout();
        }
    }
}
