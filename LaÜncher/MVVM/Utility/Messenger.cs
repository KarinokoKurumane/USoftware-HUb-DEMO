using System.Runtime.CompilerServices;
using USoftwareHUB.Models;

namespace USoftware_HUb.MVVM.Utility
{
    public static class Messenger
    {
        public static event Action<string>? ProductAdded;

        public static void SendProductAdded(string type)
        {
            ProductAdded?.Invoke(type);
        }
    }
}
