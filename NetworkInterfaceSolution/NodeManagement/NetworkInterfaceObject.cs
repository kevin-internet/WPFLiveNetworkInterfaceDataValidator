using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using ServiceManager;

namespace NodeManagement
{
    public class NetworkInterfaceObject : INetworkInterfaceObject, INotifyPropertyChanged
    {
        private string _networkInterfaceId;
        public string NetworkInterfaceId
        {
            get
            {
                return _networkInterfaceId;
            }
            set
            {
                _networkInterfaceId = value;
            }
        }

        private string _networkInterfaceName;
        public string NetworkInterfaceName
        {
            get
            {
                return _networkInterfaceName;
            }
            set
            {
                _networkInterfaceName = value;
            }
        }

        private string _networkInterfaceDescription;
        public string NetworkInterfaceDescription
        {
            get
            {
                return _networkInterfaceDescription;
            }
            set
            {
                _networkInterfaceDescription = value;
            }
        }

        private NetworkInterfaceType _networkInterfaceType;
        public NetworkInterfaceType NetworkInterfaceType
        {
            get
            {
                return _networkInterfaceType;
            }
            set
            {
                _networkInterfaceType = value;
            }
        }

        private long _networkInterfaceSpeed;
        public long NetworkInterfaceSpeed
        {
            get
            {
                return _networkInterfaceSpeed;
            }
            set
            {
                _networkInterfaceSpeed = value;
            }
        }

        private long _bytesSent;
        public long BytesSent
        {
            get
            {
                return _bytesSent;
            }
            set
            {
                _bytesSent = value;
                RaisePropertyChanged();
            }
        }

        private long _bytesReceived;
        public long BytesReceived
        {
            get
            {
                return _bytesReceived;
            }
            set
            {
                _bytesReceived = value;
                RaisePropertyChanged();
            }
        }

        private OperationalStatus _operationalStatus;
        public OperationalStatus OperationalStatus
        {
            get
            {
                return _operationalStatus;
                
            }
            set
            {
                _operationalStatus = value;
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public NetworkInterfaceObject(string nodeId, string name, string description, NetworkInterfaceType type, long speed, OperationalStatus operationStatus)
        {
            NetworkInterfaceId = nodeId;
            NetworkInterfaceName = name;
            NetworkInterfaceDescription = description;
            NetworkInterfaceType = type;
            NetworkInterfaceSpeed = speed;
            OperationalStatus = _operationalStatus;

            //ResetMetrics();
        }
        
        public void ResetMetrics()
        {
            BytesReceived = 0;
            BytesSent = 0;
        }

        //public void SimulateRandomMetrics()
        //{
        //    BytesReceived = NetworkInformationProvider.GetNetworkInformation();
        //}
    }
}
