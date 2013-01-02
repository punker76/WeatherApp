using System.IO.IsolatedStorage;

namespace Phone
{
    public static class Settings
    {
        public static bool AskedForPermission
        {
            get { return Get<bool>("AskedForPermission", false); }
            set { Set("AskedForPermission", value); }
        }
        public static bool AllowGPS
        {
            get { return Get<bool>("AllowGPS", false); }
            set { Set("AllowGPS", value); }
        }

        private static void Set(string name, object value)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(name))
                IsolatedStorageSettings.ApplicationSettings.Add(name, value);

            IsolatedStorageSettings.ApplicationSettings[name] = value;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private static T Get<T>(string name, object defaultValue)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(name))
                IsolatedStorageSettings.ApplicationSettings.Add(name, defaultValue);

            return (T) IsolatedStorageSettings.ApplicationSettings[name];
        }
    }
}