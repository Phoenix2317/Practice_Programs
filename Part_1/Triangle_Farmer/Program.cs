// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter the the triangle base size: ");
float bottom = Convert.ToSingle(Console.ReadLine());
Console.WriteLine("Enter the height of the triangle: ");
float height = Convert.ToSingle(Console.ReadLine());
float area = (bottom * height) / 2;
Console.WriteLine("The area of the triangle is: " + area);
