using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class HelpPageViewModel
    {
        private static HelpPageViewModel? _instance;
        public static HelpPageViewModel Instance => _instance ??= new HelpPageViewModel();

        private HelpPageViewModel()
        {

        }
    }
}
