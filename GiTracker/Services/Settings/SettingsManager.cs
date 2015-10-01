using System.Collections.Generic;
using Xamarin.Forms;

namespace GiTracker.Services.Settings
{
    internal class SettingsManager : ISettingsManager
    {
        private IDictionary<string, object> Properties => Application.Current.Properties;

        public void AddSetting(string name, object value)
        {
            Properties[name] = value;
        }

        public object ReadSetting(string name)
        {
            if (Properties.ContainsKey(name))
                return Properties[name];
            return null;
        }

        public void RemoveSetting(string name)
        {
            Properties.Remove(name);
        }
    }
}