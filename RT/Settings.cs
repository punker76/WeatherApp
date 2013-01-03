using Windows.Storage;

namespace RT
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

            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
                ApplicationData.Current.LocalSettings.Values.Add(name, value);

            ApplicationData.Current.LocalSettings.Values[name] = value;
        }

        private static T Get<T>(string name, object defaultValue)
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
                ApplicationData.Current.LocalSettings.Values.Add(name, defaultValue);

            return (T)ApplicationData.Current.LocalSettings.Values[name];
        }
    }
}