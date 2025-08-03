using System.Windows.Input;

namespace USofware_HUb.MVVM.Utility
{
    /// <summary>
    /// Używanie komendy w MVVM.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// Pozwala na utworzenie komendy, która może być używana w MVVM.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Odpowiedzialność za powiadomienie o zmianie stanu wykonania komendy.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Czy komenda może być wykonana.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        /// <summary>
        /// Wykonanie komendy.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter) => _execute();

    }
}
