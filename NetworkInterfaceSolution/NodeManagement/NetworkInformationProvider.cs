using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    public static class NetworkInformationProvider
    {
        public static NetworkInterface[] GetNetworkInformation()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            return interfaces;
            //foreach (NetworkInterface ni in interfaces)
            //{
            //    Console.WriteLine("    Physical Address: {0}", ni.GetPhysicalAddress().ToString());
            //}
            //foreach (NetworkInterface ni in interfaces)
            //{
            //    Console.WriteLine("Interface Name: {0}", ni.Name);
            //    Console.WriteLine("    Description: {0}", ni.Description);
            //    Console.WriteLine("    ID: {0}", ni.Id);
            //    Console.WriteLine("    Type: {0}", ni.NetworkInterfaceType);
            //    Console.WriteLine("    Speed: {0}", ni.Speed);
            //    Console.WriteLine("    Status: {0}", ni.OperationalStatus);
            //}
        }
    }
}
