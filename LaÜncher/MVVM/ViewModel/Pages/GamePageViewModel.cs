using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class GamePageViewModel
    {
        private static GamePageViewModel? _instance;
        public static GamePageViewModel Instance => _instance ??= new GamePageViewModel();

        private GamePageViewModel()
        {

        }
    }
}
