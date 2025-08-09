using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using USoftwareHUB.Models;
using USoftwareHUB.Services;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    public class SettingsPageViewModel : ObservableObject
    {
        private static SettingsPageViewModel? _instance;
        public static SettingsPageViewModel Instance => _instance ??= new SettingsPageViewModel();

        public ObservableCollection<LogItem> AllLogs { get; set; } = new();
        public ObservableCollection<LogTagType> ActiveFilters { get; set; } = new();

        public ICollectionView FilteredLogs { get; }

        public ICommand ToggleFilterCommand { get; }

        private SettingsPageViewModel()
        {
            foreach (LogTagType tag in Enum.GetValues(typeof(LogTagType)))
                ActiveFilters.Add(tag);

            FilteredLogs = CollectionViewSource.GetDefaultView(AllLogs);
            FilteredLogs.Filter = FilterLogs;

            ToggleFilterCommand = new RelayCommand(param =>
            {
                if (param is LogTagType tag)
                {
                    if (ActiveFilters.Contains(tag))
                        ActiveFilters.Remove(tag);
                    else
                        ActiveFilters.Add(tag);

                    FilteredLogs.Refresh();
                    OnPropertyChanged(nameof(ActiveFilters));
                }
            });

            LoadLogs();
        }

        private bool FilterLogs(object obj)
        {
            if (obj is LogItem log)
                return ActiveFilters.Contains(log.TagType);
            return false;
        }

        //Usunąć lub zrobić z prawdziwego zdarzenia.
        private void LoadLogs([CallerMemberName] string? propertyName = default)
        {
            ServiceLocator.TryGet(out LoggerService? logger);
            if (JsonProgramService.Read<List<LogItem>>(logger!.GetCurrentLogFile(), out var logs))
            {
                foreach (var log in logs)
                    AllLogs.Add(log);
            }
            else
                AllLogs.Add(new LogItem() { Time = DateTime.Now.ToString(), TagType = LogTagType.ERROR, Caller = propertyName ?? "E:LoadLogs", Descryption = "Nie powodzenie w załadowaniu zawartości pliku logującego. Sprawdź nazwę, albo czy w ogóle jest: logs.json" });
        }
    }
}
