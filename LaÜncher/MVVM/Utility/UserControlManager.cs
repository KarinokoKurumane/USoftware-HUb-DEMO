using System.Windows.Controls;

namespace USoftware_HUb.MVVM.Utility
{
    public static class UserControlManager
    {
        public static class UserControls
        {
            public const string Settings = "Settings";
            public const string Details = "Details";
        }

        private static readonly Dictionary<string, Func<UserControl>> _registry = new();

        public static void Register(string key, Func<UserControl> control) => _registry[key] = control;

        public static UserControl? Get(string key)
        {
            if (_registry.TryGetValue(key, out var type))
            {
                return type();
            }
            return null;
        }


        public static bool IsRegistered(string key) => _registry.ContainsKey(key);

        public static IEnumerable<string> RegisteredKeys => _registry.Keys;
    }
}
