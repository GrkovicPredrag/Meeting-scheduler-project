using DataAccessService.Composites;
using DataAccessService.Contracts;
using Logger;
using MeetingShedulerUI.Commands;
using MeetingShedulerUI.Helpers;
using MeetingShedulerUI.Helpers.Mappers;
using MeetingShedulerUI.Helpers.Publishers;
using System;
using System.Windows;
using System.Windows.Input;

namespace MeetingShedulerUI.ViewModels
{
    public class LoginFormViewModel : ViewModelBase
    {
        private readonly ILogger _logger;
        private readonly LoggedInPublisher _publisher;

        private string username;
        private string password;
        private string error;

        public event EventHandler UserLoggedIn;

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

        public string Error
        { 
            get { return this.error; }
            set
            {
                this.error = value;
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
            if (!CanLogin())
            {
                ClearFields();
                Error = "Some fields were empty. Try again!";
                return;
            }

            try
            {
                using (WCFClient<IUserService> client = new WCFClient<IUserService>("net.tcp://localhost:4000/UserService"))
                {
                    UserInfo userInfo = client.Proxy.GetUserByID(Username);
                    if (!Authenticate(userInfo.Password))
                    {
                        ClearFields();
                        Error = "Failed authentication. Try again!";
                        return;
                    }
                    FillLoggedUser(userInfo);
                    ClearFields();
                }
            }
            catch(Exception ex)
            {
                _logger.Log(ex.Message.ToString());
            }          
            _logger.Log($"Succesfully finished login process!");
            UserLoggedIn(this, EventArgs.Empty);
        }

        public bool CanLogin()
        {
            if (String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password))
                return false;

            return true;
        }

        private bool Authenticate(string pass)
        {
            if (!String.Equals(pass, Password))
                return false;

            return true;
        }

        private void FillLoggedUser(UserInfo userInfo)
        {
            using(UserMapper mapper = new UserMapper())
            {
                try
                {
                    LoggedUser.Instance.User = mapper.Map(userInfo);
                }
                catch(Exception ex)
                {
                    _logger.Log(ex.Message.ToString());
                }
            }
        }

        private void ClearFields()
        {
            Username = String.Empty;
            Password = String.Empty;
            Error = String.Empty;
        }
    }
}
