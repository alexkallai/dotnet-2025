using System.Net.NetworkInformation;

namespace Network_tools
{
    public static class NetworkTools
    {
        public static List<NetworkInterface> interfaces = new List<NetworkInterface>();
        public static string[] arpTable = GetArpTable();
        public struct NetworkInterface
        {
            public string Name;
            public string IP;
            public string subnetMask;
            public List<string> defaultGateway;
        }


        public static void EnumerateInterfaces()
        {

            foreach (System.Net.NetworkInformation.NetworkInterface networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                NetworkInterface interFace = new NetworkInterface() { defaultGateway = [] };
                // Filter for operational network interfaces
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // Console.WriteLine($"Interface: {networkInterface.Name}");
                    IPInterfaceProperties properties = networkInterface.GetIPProperties();

                    // Get IP addresses
                    foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            // Console.WriteLine($"  IP Address: {ip.Address}");
                            // Console.WriteLine($"  Subnet Mask: {ip.IPv4Mask}");
                            interFace.Name = networkInterface.Name;
                            interFace.IP = ip.Address.ToString();
                            interFace.subnetMask = ip.IPv4Mask.ToString();
                        }
                    }

                    // Get default gateway
                    foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                    {
                        Console.WriteLine($"  Default Gateway: {gateway.Address}");
                        interFace.defaultGateway.Append( gateway.Address.ToString() );

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
