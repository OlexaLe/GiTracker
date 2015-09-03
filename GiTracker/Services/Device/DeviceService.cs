using System;

namespace GiTracker.Services.Device
{
    public class DeviceService : IDeviceService
    {
        public void OpenUri(Uri uri)
        {
            Xamarin.Forms.Device.OpenUri(uri);
        }
    }
}