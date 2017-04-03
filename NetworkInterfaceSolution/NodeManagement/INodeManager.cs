using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagement
{
    public interface INodeManager
    {
        void AddNode(INetworkInterfaceObject node);

        void RemoveNode(string nodeId);

        INetworkInterfaceObject GetNode(string nodeId);

        List<INetworkInterfaceObject> GetNodes();
    }
}
