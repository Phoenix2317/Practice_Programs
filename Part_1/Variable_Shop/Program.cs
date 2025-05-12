internal class Program
{
    private static void Main(string[] args)
    {

        byte micro = 1;
        micro = 0;

        short tiny = 2;
        tiny = -2;

        int normal = 3;
        normal = -3;

        long macro = 4L;
        macro = -4L;

        sbyte nano = -5;
        nano = -50;

        ushort yin = 60_000;
        yin = 59;

        uint yang = 700_000_000U;
        yang = 69u;

        ulong yaw = 800_000_000_000_000_037ul;
        yaw = 420UL;

        float ding = 9E10f;
        ding = 10E3f;

        double daw = 10E34;
        daw = 30E32;

        decimal dong = 11E15m;
        dong = 12E-15m;

        bool yes = true;
        yes = false;

        char letter = 'a';
        letter = 'b';

        string word = "Dancer niner";
        word = "Dork";

        

        Console.WriteLine(micro);
        Console.WriteLine(tiny);
        Console.WriteLine(normal);
        Console.WriteLine(macro);
        Console.WriteLine(dong);
        Console.WriteLine(yes);
        Console.WriteLine(yin);
        Console.WriteLine(yang);
        Console.WriteLine(nano);
        Console.WriteLine(yaw);
        Console.WriteLine(ding);
        Console.WriteLine(daw);
        Console.WriteLine(letter);
        Console.WriteLine(word);
        

    }
}