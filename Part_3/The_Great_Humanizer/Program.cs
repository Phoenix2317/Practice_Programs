using Humanizer;


Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30).Humanize()}");
Console.WriteLine($"When is the party? {DateTime.UtcNow.AddDays(3).Humanize()}");
Console.WriteLine($"When is the Play? {DateTime.UtcNow.AddHours(1.5).Humanize()}");
