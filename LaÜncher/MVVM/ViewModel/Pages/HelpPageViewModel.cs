using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class HelpPageViewModel
    {
        public ICommand? GithubContactCommand { get; }
        public ICommand? GmailContactCommand { get; }
        public ICommand? DiscordContactCommand { get; }

        private static HelpPageViewModel? _instance;
        public static HelpPageViewModel Instance => _instance ??= new HelpPageViewModel();

        private HelpPageViewModel()
        {
            GithubContactCommand = new RelayCommand(x => GithubContactOperation());
            GmailContactCommand = new RelayCommand(x => GmailContactOperation());
            DiscordContactCommand = new RelayCommand(x => DiscordContactOperation());
        }

        private void GithubContactOperation()
        {
            // TODO: Logika kontaktu Github
            MessageBox.Show("Nawiązano kontakt z Github");
        }

        private void GmailContactOperation()
        {
            // TODO: Logika kontaktu Gmail
            MessageBox.Show("Nawiązano kontakt z Gmail");
        }

        private void DiscordContactOperation()
        {
            // TODO: Logika kontaktu Discord
            MessageBox.Show("Nawiązano kontakt z Discord");
        }
    }
}
