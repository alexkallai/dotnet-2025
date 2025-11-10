using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_tools
{
    public static class NetworkTools
    {
        public static List<InterFace> interfaces = new List<InterFace>();
        public struct InterFace
        {
            public string Name;
            public string IP;
            public string subnetMask;
            public string[] defaultGateway;
        }


        public static void EnumerateInterfaces()
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

        public static bool IsIpAddressLive(string ipAddress)
        {
            try
            {
                // Get the ARP table
                var arpTable = GetArpTable();

                // Check if the IP address exists in the ARP table
                foreach (var entry in arpTable)
                {
                    if (entry.Contains(ipAddress))
                    {
                        return true; // IP address is live
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false; // IP address is not live
        }

        private static string[] GetArpTable()
        {
            // Run the "arp -a" command to get the ARP table
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "arp",
                    Arguments = "-a",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Split the output into lines
            return output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

    }


}
