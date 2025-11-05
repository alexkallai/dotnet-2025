int number1;
int number2;


while (true)
{
    Console.WriteLine("Please type the first number!");
    number1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please type the second number!");
    number2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Please select the operation:");
    Console.WriteLine("[A]dd numbers");
    Console.WriteLine("[S]ubtract numbers");
    Console.WriteLine("[M]multiply numbers");

    while (true)
    {
        string selection = Console.ReadLine();
        bool finished = false;
        switch (selection)
        {
            case "A":
                Console.WriteLine(number1 + number2);
                finished = true;
                break;
            case "S":
                Console.WriteLine(number1 - number2);
                finished = true;
                break;
            case "M":
                Console.WriteLine(number1 * number2);
                finished = true;
                break;
            default:
                Console.WriteLine("Incorrect input, please retry!");
                break;
        }
        if (finished)
        {
            Console.WriteLine("Restarting! \n");
            break;
        }
    }

}

