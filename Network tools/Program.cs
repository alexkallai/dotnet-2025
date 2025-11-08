using Network_tools;
using Spectre.Console;
using System;
using System.Collections.Generic;
using static Network_tools.NetworkTools;

class Program
{
    static Stack<Action> menuStack = new Stack<Action>();
    static int selectionIndex;

    static void Main(string[] args)
    {
        NetworkTools.EnumerateInterfaces();
        // Start with the main menu
        menuStack.Push(MainMenu);
        menuStack.Peek().Invoke(); // Display the top menu
    }

    static void MainMenu()
    {
        Console.Clear();
        var feature = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold yellow]Select a feature:[/]")
                .AddChoices(new[] { "Network Scan", "Coming up", "Exit" })
        );

        switch (feature)
        {
            case "Network Scan":
                menuStack.Push(NetworkScanMenu);
                menuStack.Peek().Invoke(); // Navigate to Network Scan menu
                break;
            case "Coming up...":
                HandleComingUp();
                menuStack.Peek().Invoke(); // Stay in the main menu
                break;
            case "Exit":
                Environment.Exit(0); // Exit the application
                break;
        }
    }

    static void NetworkScanMenu()
    {
        Console.Clear();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green]Select a network scan option:[/]")
                .AddChoices(new[] { "List Network Interfaces", "Scan Active Interfaces", "Back" })
        );

        switch (option)
        {
            case "List Network Interfaces":
                ListNetworkInterfaces();
                menuStack.Peek().Invoke(); // Stay in the current menu
                break;
            case "Scan Active Interfaces":
                ScanActiveInterfaces();
                menuStack.Peek().Invoke(); // Stay in the current menu
                break;
            case "Back":
                menuStack.Pop(); // Remove current menu from stack
                menuStack.Peek().Invoke(); // Go back to the previous menu
                break;
        }
    }

    static void HandleComingUp()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold red]Feature coming soon![/]");
        Console.ReadKey();
    }

    static void ListNetworkInterfaces()
    {
        var names = interfaces.Select(iface => $"{iface.IP}, \t\t {iface.Name}").ToList();
        Console.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Listing all network interfaces...[/]");
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Found interfaces:")
            .AddChoices(names));
        // Add logic to list network interfaces
        selectionIndex = names.IndexOf(selection);
        menuStack.Push(ScanActiveIpsInRange);
        menuStack.Peek().Invoke(); // Navigate to Network Scan menu
        Console.Clear();
    }

    static void ScanActiveInterfaces()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold green]Scanning active network interfaces...[/]");
        // Add logic to scan active interfaces
        Console.ReadKey();
    }

    static void ScanActiveIpsInRange()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold green]Scanning active IP addresses...[/]");
        var interfaceData = NetworkTools.interfaces[selectionIndex];
        string IPBase = interfaceData.IP.Split('.')[0..2].ToString();


        var table = new Table().Centered();

        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                table.AddColumn("Active IP addresses");
                for(int i = 0; i < 257;  i++) {
                    string currentIP = $"{IPBase}.{i}";
                    if (NetworkTools.IsHostUp(currentIP))
                    {
                        table.AddRow(currentIP);
                        ctx.Refresh();
                    }

                }


            });


        Console.ReadKey();
        Console.Clear();

    }
}
