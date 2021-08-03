using DataAccessService.Composites;
using DataAccessService.Contracts;
using Logger;
using MeetingShedulerUI.Commands;
using MeetingShedulerUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingShedulerUI.ViewModels
{
    public class LoginFormViewModel : ViewModelBase
    {
        private readonly ILogger _logger;

        private string username;
        private string password;

        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand { get; set; }

        public LoginFormViewModel()
        {
            _logger = LoggerFactory.Create(LoggerFactory.LoggingOption.Output);
            LoginCommand = new LoginCommand(_logger, this);
        }

        public void Login()
        {
            try
            {
                using (WCFClient<IUserService> client = new WCFClient<IUserService>("net.tcp://localhost:4000/UserService"))
                {
                     List<UserInfo> list = client.Proxy.GetAllUsers();
                }
            }
            catch(Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }          
            _logger.Log($"Succesfully retrieved user info!");
        }

        public bool CanLogin()
        {
            if (Username == null || Password == null)
                return false;

            if (String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password))
                return false;

            return true;
        }
    }
}
