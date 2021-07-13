using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.ViewModels
{
    public class MainViewModel 
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            ILogger logger =  LoggerFactory.Create(LoggerFactory.LoggingOption.File);
            
            CurrentViewModel = new HomeViewModel();
            logger.Log("Mapped the view model again!!");
        }
    }
}
