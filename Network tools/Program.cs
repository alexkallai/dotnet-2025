using Network_tools;
using Spectre.Console;
using static Network_tools.NetworkTools;

internal static class Program
{
    // A stack to manage menu navigation. Each Action represents a menu screen.
    private static readonly Stack<Action> _menuStack = new Stack<Action>();

    // --- State variables shared between menu actions ---
    // These are used to pass data between different menu screens.
    private static int _selectedInterfaceIndex;
    private static string _selectedIpForPortScan = "";
    private const string BackChoice = "[grey]Back[/]";

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public static void Main(string[] args)
    {
        // Populate network interface data at startup.
        NetworkTools.EnumerateInterfaces();

        // Set the initial menu and start the application loop.
        _menuStack.Push(ShowMainMenu);
        _menuStack.Peek().Invoke(); // Display the top-most menu.
    }

    #region Menu Methods

    /// <summary>
    /// Displays the main menu.
    /// </summary>
    private static void ShowMainMenu()
    {
        Console.Clear();
        var feature = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold yellow]Select a feature:[/]")
                .AddChoices("Network Scan", "Exit"));

        switch (feature)
        {
            case "Network Scan":
                _menuStack.Push(ShowNetworkScanMenu);
                _menuStack.Peek().Invoke(); // Navigate to the Network Scan menu.
                break;
            case "Exit":
                Environment.Exit(0); // Exit the application.
                break;
        }
    }

    /// <summary>
    /// Displays the network scanning options menu.
    /// </summary>
    private static void ShowNetworkScanMenu()
    {
        Console.Clear();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green]Select a network scan option:[/]")
                .AddChoices("List Network Interfaces", BackChoice));

        switch (option)
        {
            case "List Network Interfaces":
                // This is a direct method call, not a new menu on the stack.
                // It will handle its own subsequent navigation.
                SelectNetworkInterface();
                break;
            case BackChoice:
                _menuStack.Pop(); // Remove current menu from the stack.
                _menuStack.Peek().Invoke(); // Go back to the previous menu.
                break;
        }
    }

    /// <summary>
    /// Displays a list of network interfaces for the user to select for scanning.
    /// </summary>
    private static void SelectNetworkInterface()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Listing all network interfaces...[/]");

        // Format choices for better alignment.
        var interfaceChoices = NetworkTools.Interfaces
            .Select(iface => $"[white]{iface.IP.PadRight(18)}[/] - [dim]{iface.Name}[/]")
            .ToList();

        interfaceChoices.Add(BackChoice);

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an interface to scan:")
                .AddChoices(interfaceChoices));

        if (selection == BackChoice)
        {
            // If "Back" is chosen, simply return to the calling menu.
            // The ShowNetworkScanMenu will be invoked again by the caller's logic if needed.
            // In this specific stack-based model, we must re-invoke the previous menu.
            _menuStack.Peek().Invoke();
        }
        else
        {
            // Find the index of the selected interface to pass to the next step.
            _selectedInterfaceIndex = interfaceChoices.IndexOf(selection);

            // Navigate to the next step: scanning for active IPs.
            _menuStack.Push(ScanForActiveIps);
            _menuStack.Peek().Invoke();
        }
    }

    /// <summary>
    /// Scans the subnet of the selected interface for live IP addresses.
    /// </summary>
    private static void ScanForActiveIps()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold green]Scanning for active IP addresses...[/]");

        var selectedInterface = NetworkTools.Interfaces[_selectedInterfaceIndex];
        string ipAddressBase = string.Join(".", selectedInterface.IP.Split('.').Take(3));

        var activeIpAddresses = new List<string>();
        var table = new Table().LeftAligned().Width(40);

        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                table.AddColumn("Active IP Addresses");
                // Scan the common host range for a /24 subnet (1-254).
                for (int i = 1; i < 255; i++)
                {
                    string currentIp = $"{ipAddressBase}.{i}";
                    if (NetworkTools.IsIpAddressLive(currentIp))
                    {
                        table.AddRow(currentIp);
                        activeIpAddresses.Add(currentIp);
                        ctx.Refresh();
                    }
                }
            });

        var promptChoices = new List<string>(activeIpAddresses);
        promptChoices.Add(BackChoice);

        Console.Clear();
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Found active IP addresses:")
                .PageSize(40)
                .AddChoices(promptChoices));

        if (selection == BackChoice)
        {
            _menuStack.Pop(); // Pop ScanForActiveIps
            _menuStack.Peek().Invoke(); // Go back to the previous menu (SelectNetworkInterface)
        }
        else
        {
            _selectedIpForPortScan = selection;
            _menuStack.Push(ScanPortsOnSelectedIp);
            _menuStack.Peek().Invoke();
        }
    }

    /// <summary>
    /// Scans ports 0-65535 on the selected IP address.
    /// </summary>
    private static void ScanPortsOnSelectedIp()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        // Start a background task to listen for a key press to cancel the scan.
        Task.Run(() =>
        {
            Console.ReadKey(true); // Blocks until a key is pressed.
            cancellationTokenSource.Cancel(); // Signal cancellation.
        }, cancellationTokenSource.Token);

        const int MaxPortNumber = 65535;
        Console.Clear();
        AnsiConsole.MarkupLine($"[bold green]Scanning active ports for IP [underline]{_selectedIpForPortScan}[/][/]");
        AnsiConsole.MarkupLine("[yellow]Press any key to stop the scan...[/]\n");

        var openPorts = new List<string>();
        var table = new Table().LeftAligned().Width(40);
        int lastScannedPort = 0;

        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                table.AddColumn("Active Ports");
                for (int port = 0; port <= MaxPortNumber; port++)
                {
                    lastScannedPort = port;
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        break; // Exit the loop if user pressed a key.
                    }

                    // Correctly calculate percentage using floating-point division.
                    double percentage = (double)port / MaxPortNumber * 100;
                    table.Title($"Scanning {port}/{MaxPortNumber} ({percentage:F2}%)");

                    if (NetworkTools.IsPortOpen(_selectedIpForPortScan, port, 20))
                    {
                        table.AddRow(port.ToString());
                        openPorts.Add(port.ToString());
                    }

                    // Refresh the live display periodically to reduce flicker and improve performance.
                    if (port % 10 == 0)
                    {
                        ctx.Refresh();
                    }
                }
            });

        if (cancellationTokenSource.IsCancellationRequested)
        {
            AnsiConsole.MarkupLine("\n[yellow]Scanning stopped by user.[/]");
        }

        Console.Clear();
        if (openPorts.Any())
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Found [green]{openPorts.Count}[/] open port(s) in the range 0-{lastScannedPort}:")
                    .PageSize(20)
                    .AddChoices(openPorts));
            // The selection is currently not used, but kept for behavior consistency.
        }
        else
        {
            AnsiConsole.MarkupLine($"[yellow]No open ports found for {_selectedIpForPortScan} in the scanned range 0-{lastScannedPort}.[/]");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        // Navigate back two levels: from Port Scan -> IP List -> Interface List menu.
        _menuStack.Pop(); // Pop ScanPortsOnSelectedIp
        _menuStack.Pop(); // Pop ScanForActiveIps
        _menuStack.Peek().Invoke();
    }

    #endregion
}