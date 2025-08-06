using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class SettingsPageViewModel
    {
        private static SettingsPageViewModel? _instance;
        public static SettingsPageViewModel Instance => _instance ??= new SettingsPageViewModel();

        private SettingsPageViewModel()
        {

        }
    }
}
