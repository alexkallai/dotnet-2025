using Network_tools;
using Spectre.Console;
using static Network_tools.NetworkTools;

class Program
{
    static Stack<Action> menuStack = new Stack<Action>();
    static int selectionIndex;

    public static string selectedIpForPortscan = "";

    static void Main(string[] args)
    {
        NetworkTools.EnumerateInterfaces();
        // Start with the main menu
        menuStack.Push(MainMenu);
        menuStack.Peek().Invoke(); // Display the top menu
    }

    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var feature = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Select a feature:[/]")
                    .AddChoices(new[] { "Network Scan", "Exit" })
            );

            switch (feature)
            {
                case "Network Scan":
                    menuStack.Push(NetworkScanMenu);
                    menuStack.Peek().Invoke(); // Navigate to Network Scan menu
                    break;
                case "Exit":
                    Environment.Exit(0); // Exit the application
                    break;
            }
        }
    }

    static void NetworkScanMenu()
    {
        Console.Clear();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green]Select a network scan option:[/]")
                .AddChoices(new[] { "List Network Interfaces", "Back" })
        );

        switch (option)
        {
            case "List Network Interfaces":
                ListNetworkInterfaces();
                menuStack.Peek().Invoke(); // Stay in the current menu
                break;
            case "Back":
                menuStack.Pop(); // Remove current menu from stack
                menuStack.Peek().Invoke(); // Go back to the previous menu
                break;
        }
    }


    static void ListNetworkInterfaces()
    {
        var names = interfaces.Select(iface => $"{iface.IP.PadRight(15)} - {iface.Name}").ToList();
        names.Add("Back");

        Console.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Listing all network interfaces...[/]");
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Found interfaces:")
            .AddChoices(names));

        if (selection == "Back")
        {
            menuStack.Pop();
            menuStack.Peek().Invoke(); // Go back to the previous menu
        }

        // Add logic to list network interfaces
        selectionIndex = names.IndexOf(selection);
        menuStack.Push(ScanActiveIpsInRange);
        menuStack.Peek().Invoke(); // Navigate to Network Scan menu
        Console.Clear();
    }


    static void ScanActiveIpsInRange()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold green]Scanning active IP addresses...[/]");
        var interfaceData = NetworkTools.interfaces[selectionIndex];
        string IPBase = string.Join(".", interfaceData.IP.Split('.').Take(3));

        List<string> liveIpAddresses = [];


        var table = new Table().LeftAligned().Width(40);

        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                table.AddColumn("Active IP addresses");
                for (int i = 0; i < 257; i++)
                {
                    string currentIP = $"{IPBase}.{i}";
                    if (NetworkTools.IsIpAddressLive(currentIP))
                    {
                        table.AddRow(currentIP);
                        liveIpAddresses.Add(currentIP);
                        ctx.Refresh();
                    }

                }


            });

        liveIpAddresses.Add("Back");
        Console.Clear();
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Found active IP addresses:")
            .PageSize(50)
            .AddChoices(liveIpAddresses));


        if (selection == "Back")
        {
            menuStack.Pop();
            menuStack.Peek().Invoke(); // Go back to the previous menu
        }

        selectedIpForPortscan = selection;

        menuStack.Push(ScanPortsForIp);
        menuStack.Peek().Invoke(); 

        Console.Clear();

    }

    static void ScanPortsForIp()
    {
        var cts = new CancellationTokenSource();

        // Start a new Task to listen for a key press  
        // This task will run in the background without blocking the main UI thread  
        Task.Run(() =>
        {
            Console.ReadKey(true); // Read a key, 'true' means don't display it  
            cts.Cancel(); // Signal cancellation once a key is pressed  
        });

        const int MAX_PORT_NUMBER = 65535;
        Console.Clear();
        AnsiConsole.MarkupLine($"[bold green]Scanning active ports for IP {selectedIpForPortscan}[/]");
        AnsiConsole.MarkupLine($"Press a button to stop the scan...");


        List<string> openPorts = [];


        var table = new Table().LeftAligned().Width(40);

        int i = 0;
        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                table.AddColumn("Active ports:");
                for (i=0; i < MAX_PORT_NUMBER; i++)
                {

                    if (cts.Token.IsCancellationRequested)
                    {
                        AnsiConsole.MarkupLine("\n[yellow]Scanning stopped by user.[/]");
                        break; // Exit the loop
                    }

                    table.Title($"Scanning {i}/{MAX_PORT_NUMBER}");
                    if (NetworkTools.IsPortOpen(selectedIpForPortscan, i, 20))
                    {
                        table.AddRow(i.ToString());
                        openPorts.Add(i.ToString());
                    }
                    ctx.Refresh();
                }
            });

        Console.Clear();
        if(openPorts.Count != 0)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"Found open ports in the range 0-{i}:")
                .PageSize(50)
                .AddChoices(openPorts));
        }


        Console.Clear();
        menuStack.Pop(); // Remove current menu from stack
        menuStack.Pop(); // Remove current menu from stack
        menuStack.Peek().Invoke();

    }
}
