using Logger;
using MeetingShedulerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly ILogger _logger;
        public LoginFormViewModel ViewModel { get; set; }

        public LoginCommand()
        {

        }

        public LoginCommand(ILogger logger, LoginFormViewModel viewModel)
        {
            ViewModel = viewModel;
            _logger = logger;
        }


        public override void Execute(object parameter)
        {
            this.ViewModel.Login();
        }
    }
}
