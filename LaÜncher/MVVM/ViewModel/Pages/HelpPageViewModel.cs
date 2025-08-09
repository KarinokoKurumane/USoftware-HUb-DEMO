using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using USoftware_HUb.MVVM.Models;
using USoftwareHUB.Models;
using USoftwareHUB.Services;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class HelpPageViewModel: ObservableObject
    {
        public ObservableCollection<FaqEntry> FaqList { get; set; } = new();

        public ICommand? GithubContactCommand { get; }
        public ICommand? GmailContactCommand { get; }
        public ICommand? DiscordContactCommand { get; }

        private static HelpPageViewModel? _instance;
        public static HelpPageViewModel Instance => _instance ??= new HelpPageViewModel();

        private HelpPageViewModel()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component", LogTagType.INFO, "HelpPageViewModel .ctor");

            LoadFaq();
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

        //usunąć po testach
        private void LoadFaq()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Commisions", "faq.json");
            loggerService!.Log($"Start loading FAQ items from\n{path}", LogTagType.INFO);

            if (JsonProgramService.Read<List<FaqEntry>>(path, out var _result))
                foreach (var item in _result)
                {
                    FaqList.Add(item);
                }
            else
            {
                loggerService!.Log($"Error FAQ file data", LogTagType.WARNING);
                FaqList.Add(new() { Question = "Problem z danymi?", Answer = "Upewnij się, że zawartość pliku nie została uszkodzona" });
            }
        }

    }
}
