// See https://aka.ms/new-console-template for more information

Console.WriteLine(Adds.Add(1, 2)); // Output: 3
Console.WriteLine(Adds.Add(1.5, 2.5)); // Output: 4
Console.WriteLine(Adds.Add("Hello, ", "World!")); // Output: Hello, World!
Console.WriteLine(Adds.Add(DateTime.Now, TimeSpan.FromDays(1))); // Output: Tomorrow's date

public static class Adds
{ 
    public static dynamic Add(dynamic a, dynamic b) => a + b;
    //Downside of using dynamic is if both objects are of different types, it will throw an exception at runtime.
    //For example, if you try to add an int and a DateTime, it will throw a runtime exception.
}