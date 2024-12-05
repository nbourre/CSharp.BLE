using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBleDevice
    {
        Task<IEnumerable<string>> GetAvailableDevicesAsync();
        Task ConnectToDeviceAsync(string deviceName);
        Task DisconnectAsync();
        Task SendDataAsync(byte[] data);
        Task<byte[]> ReceiveDataAsync();
    }
}
