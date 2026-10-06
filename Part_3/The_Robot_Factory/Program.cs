// See https://aka.ms/new-console-template for more information

using System.Dynamic;

int ID = 1;

var robot = (IDictionary<string, object>)new ExpandoObject();

while (true)
{
    Console.WriteLine($"You are making robot #{ID}.");

    robot["ID"] = ID;

    Console.Write("Do you want to add a name for the robot? (y/n): ");
    int? response = Console.ReadLine()[0];
    if(response != null && response == 'y')
    {
        Console.Write("Enter the name of the robot: ");
        string? name = Console.ReadLine();
        while(name == null)
        {
         Console.WriteLine("Invalid name. Please enter a valid name for the robot: ");
            name = Console.ReadLine();
        }
        robot["Name"] = name;
    }

    Console.Write("Do you want to provide the size of the robot? (y/n): ");
    response = Console.ReadLine()[0];
    if (response != null && response == 'y')
    {
        Console.Write("Enter the height of the robot: ");
        string? height = Console.ReadLine();
        while (height == null || !int.TryParse(height, out _))
        {
            Console.WriteLine("Invalid height. Please enter a valid height for the robot: ");
            height = Console.ReadLine();
        }
        robot["Height"] = height;

        Console.WriteLine("Enter the width of the robot: ");
        string? width = Console.ReadLine();
        while (width == null || !int.TryParse(width, out _))
        {
            Console.WriteLine("Invalid width. Please enter a valid width for the robot: ");
            width = Console.ReadLine();
        }
        robot["Width"] = width;
    }

    Console.Write("Do you want to color the robot? (y/n): ");
    response = Console.ReadLine()[0];
    if (response != null && response == 'y')
    {
        Console.Write("Enter the color of the robot: ");
        string? color = Console.ReadLine();
        while(color == null)
        {
            Console.WriteLine("Invalid color. Please enter a valid color for the robot: ");
            color = Console.ReadLine();
        }
        robot["Color"] = color;
    }

    foreach(KeyValuePair<string, object> propterty in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{propterty.Key}: {propterty.Value}");
    }

    ID++;
}

