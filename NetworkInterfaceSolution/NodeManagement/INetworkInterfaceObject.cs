using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagement
{
    public interface INetworkInterfaceObject
    {
        string NetworkInterfaceId { get; set; }
        string NetworkInterfaceName { get; set; }
        string NetworkInterfaceDescription { get; set; }
        NetworkInterfaceType NetworkInterfaceType { get; set; }
        long NetworkInterfaceSpeed{ get; set; }

        long BytesSent { get; set;  }
        long BytesReceived { get; set;  }

        OperationalStatus OperationalStatus { get; set; }

        //void SetOnline();

        /// <summary>
        /// Bring the node offline
        /// </summary>
        /// <returns></returns>
        //void SetOffline();

        /// <summary>
        /// Timestamp of the node's last online time
        /// </summary>
        //DateTime OnlineTime { get; }

    }
}
