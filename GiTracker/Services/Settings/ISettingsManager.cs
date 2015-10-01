namespace GiTracker.Services.Settings
{
    public interface ISettingsManager
    {
        void AddSetting(string name, object value);
        object ReadSetting(string name);
        void RemoveSetting(string name);
    }
}