using System;
using System.Collections.Generic;
using Windows.Devices.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;

namespace mBotRemoteController
{
    class BluetoothConnection
    {
        private List<DeviceInformation> DeviceList = new List<DeviceInformation>();
        private List<GattCharacteristic> WriteableCharacteristics = new List<GattCharacteristic>();
        private string _aqsAllBLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";
        private string[] _requestedBLEProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.Bluetooth.Le.IsConnectable", };
        private GattCharacteristic WriteCharacteristic;

        public BluetoothConnection()
        {
            var watcher = DeviceInformation.CreateWatcher(_aqsAllBLEDevices, _requestedBLEProperties, DeviceInformationKind.AssociationEndpoint);
            watcher.Added += (DeviceWatcher sender, DeviceInformation devInfo) =>
            {
                if (DeviceList.FirstOrDefault(d => d.Id.Equals(devInfo.Id) || d.Name.Equals(devInfo.Name)) == null)
                    DeviceList.Add(devInfo);
            };
            watcher.Updated += (_, __) => { };

            watcher.EnumerationCompleted += (DeviceWatcher sender, object arg) => { sender.Stop(); };
            watcher.Stopped += (DeviceWatcher sender, object arg) => { DeviceList.Clear(); sender.Start(); };
            watcher.Start();
        }

        public Tuple<string, string>[] GetDeviceNames()
        {
            return DeviceList.Where(d => !string.IsNullOrEmpty(d.Name)).Select(d => new Tuple<string, string>(d.Name, d.Id)).ToArray();
        }

        public Tuple<string, string>[] GetCharacteristics()
        {
            return WriteableCharacteristics.Select(d => new Tuple<string, string>(d.Uuid.ToString(), d.Uuid.ToString())).ToArray();
        }

        public void SetCharacteristic(int index)
        {
            WriteCharacteristic = WriteableCharacteristics[index];
        }

        public async Task Connect(string deviceId)
        {
            try
            {
                BluetoothLEDevice selectedDevice = await BluetoothLEDevice.FromIdAsync(deviceId).AsTask();
                if (selectedDevice != null)
                {
                    var result = await selectedDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);

                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        IReadOnlyList<GattDeviceService> services = result.Services;
                        foreach (var s in services)
                        {
                            var result1 = await s.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                            if (result1.Status == GattCommunicationStatus.Success)
                            {
                                var characteristics = result1.Characteristics;
                                if (characteristics.Count > 0)
                                {
                                    foreach (var ch in characteristics)
                                    {
                                        if (CanWrite(ch))
                                            WriteableCharacteristics.Add(ch);
                                    }

                                }
                            }
                        }

                    }
                    else
                    {
                        throw new Exception("Device is unreachable");
                    }

                    WriteCharacteristic = WriteableCharacteristics[0];
                }
            }
            catch
            {
                throw new Exception("Device is unreachable");
            }
        }

        public async Task FindAllServices(GattDeviceService service)
        {
            try
            {
                IReadOnlyList<GattCharacteristic> characteristics = null;
                var accessStatus = await service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    var result = await service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        characteristics = result.Characteristics;
                    }
                    else
                    {

                        // On error, act as if there are no characteristics.
                        characteristics = new List<GattCharacteristic>();
                    }
                    foreach (GattCharacteristic c in characteristics)
                    {
                        // add to a list
                    }
                }
            }
            catch
            {

            }
        }

        public async Task Send(IBuffer buffer)
        {
            if (WriteableCharacteristics != null)
            {
                GattWriteResult result = await WriteCharacteristic.WriteValueWithResultAsync(buffer);
                Console.WriteLine(result);
            }
        }

        private IBuffer ToByte(string data)
        {
            return CryptographicBuffer.ConvertStringToBinary(data,
                    BinaryStringEncoding.Utf8);
        }

        private bool CanWrite(GattCharacteristic characteristic)
        {
            return characteristic != null ?
                (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write) ||
                 characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse) ||
                 characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.ReliableWrites) ||
                 characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WritableAuxiliaries))
                : false;

        }


    }
}
