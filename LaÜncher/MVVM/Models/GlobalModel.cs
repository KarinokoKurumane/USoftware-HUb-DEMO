using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Models
{
    public static class GlobalModel
    {
        public static int globalCounter = 0;

        private static LoggerService? logger;

        public static LoggerService? loggerService
        {
            get
            {
                if (logger == null)
                    ServiceLocator.TryGet(out logger);
                return logger;
            }
            set => logger ??= value;
        }
    }
}
