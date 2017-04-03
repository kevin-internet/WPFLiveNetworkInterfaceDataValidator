using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagement
{
    public class NodeManager : INodeManager
    {
        private readonly List<INetworkInterfaceObject> _nodes;

        public NodeManager()
        {
            _nodes = new List<INetworkInterfaceObject>();
        }

        public void AddNode(INetworkInterfaceObject node)
        {
            if (!_nodes.Exists(x => x.NetworkInterfaceId == node.NetworkInterfaceId))
            {
                _nodes.Add(node);
            }
            else
            {
                throw new Exception(string.Format("Cannot add node. NodeId {0} already exists.", node.NetworkInterfaceId));
            }
        }

        public void RemoveNode(string nodeId)
        {
            var existingNode = GetNode(nodeId);

            if (existingNode != null)
            {
                _nodes.Remove(existingNode);
            }
            else
            {
                throw new Exception(string.Format("Cannot remove node. NodeId {0} does not exist", nodeId));
            }
        }

        public INetworkInterfaceObject GetNode(string nodeId)
        {
            return _nodes.Find(x => x.NetworkInterfaceId == nodeId);
        }

        public List<INetworkInterfaceObject> GetNodes()
        {
            return _nodes;
        }
    }
}
