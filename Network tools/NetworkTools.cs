using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_tools
{
    public class NetworkTools
    {
        public static List<InterFace> interfaces = new List<InterFace>();
        public struct InterFace
        {
            public string Name;
            public string IP;
            public string subnetMask;
            public string[] defaultGateway;
        }
        public NetworkTools() {
            EnumerateInterfaces();
        }

        public void EnumerateInterfaces()
        {

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                InterFace interFace = new InterFace();
                // Filter for operational network interfaces
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    Console.WriteLine($"Interface: {networkInterface.Name}");
                    IPInterfaceProperties properties = networkInterface.GetIPProperties();

                    // Get IP addresses
                    foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"  IP Address: {ip.Address}");
                            Console.WriteLine($"  Subnet Mask: {ip.IPv4Mask}");
                            interFace.Name = networkInterface.Name;
                            interFace.IP = ip.Address.ToString();
                            interFace.subnetMask = ip.IPv4Mask.ToString();
                        }
                    }

                    // Get default gateway
                    foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                    {
                        Console.WriteLine($"  Default Gateway: {gateway.Address}");
                        
                    }

                    Console.WriteLine();
                }
                interfaces.Add(interFace);
            }
            }
        }

}
