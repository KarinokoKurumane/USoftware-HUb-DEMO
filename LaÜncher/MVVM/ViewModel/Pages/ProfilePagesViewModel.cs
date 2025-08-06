using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ProfilePagesViewModel
    {
        private static ProfilePagesViewModel? _instance;
        public static ProfilePagesViewModel Instance => _instance ??= new ProfilePagesViewModel();

        private ProfilePagesViewModel()
        {

        }
    }
}
