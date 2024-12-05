using Core.Interfaces;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;

namespace Infrastructure.Services
{
    public class BleService : IBleDevice
    {
        private readonly IAdapter _adapter;
        private IDevice _connectedDevice;

        public BleService()
        {
            var ble = CrossBluetoothLE.Current;
            _adapter = ble.Adapter;
        }

        public async Task<IEnumerable<string>> GetAvailableDevicesAsync()
        {
            var devices = await _adapter.GetSystemConnectedOrPairedDevicesAsync();
            return devices.Select(d => d.Name);
        }

        public async Task ConnectToDeviceAsync(string deviceName)
        {
            var devices = await _adapter.GetSystemConnectedOrPairedDevicesAsync();
            var device = devices.FirstOrDefault(d => d.Name == deviceName);

            if (device == null)
                throw new DeviceNotFoundException("Device not found.");

            await _adapter.ConnectToDeviceAsync(device);
            _connectedDevice = device;
        }

        public async Task DisconnectAsync()
        {
            if (_connectedDevice != null)
            {
                await _adapter.DisconnectDeviceAsync(_connectedDevice);
                _connectedDevice = null;
            }
        }

        public async Task SendDataAsync(byte[] data)
        {
            // Implémentation pour envoyer des données
        }

        public async Task<byte[]> ReceiveDataAsync()
        {
            // Implémentation pour recevoir des données
            return new byte[0];
        }
    }
}
