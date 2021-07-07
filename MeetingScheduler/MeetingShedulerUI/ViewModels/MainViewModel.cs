using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logger.LogHelper;

namespace MeetingShedulerUI.ViewModels
{
    public class MainViewModel 
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
            LogHelper.Log(LogTarget.EventLog, "Mapped the viewModel.");
            LogHelper.Log(LogTarget.File, "Mapped the viewModel.");
            LogHelper.Log(LogTarget.OutputLog, "Mapped the viewModel.");
        }
    }
}
