using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {

        Arrow sell = new Arrow();
        sell.Build();
        sell.getCost();

    }



    enum arrowHead { steel, wood, obsidian };
    enum fletching { plastic, t_feathers, g_feathers };

    class Arrow
    {
        public Arrow()
        {
            aHead = arrowHead.steel;
            tail = fletching.plastic;
            shaft = 60;
        }

        public arrowHead aHead;
        public fletching tail;
        public int shaft;

        public void getCost()
        {
            float cost = 0;
            if (aHead == arrowHead.steel)
            {
                cost += 10;
            }
            else if (aHead == arrowHead.wood)
            {
                cost += 3;
            }
            else if (aHead == arrowHead.obsidian)
            {
                cost += 5;
            }

            if (tail == fletching.plastic)
            {
                cost += 10;
            }
            else if (tail == fletching.t_feathers)
            {
                cost += 5;
            }
            else if (tail == fletching.g_feathers)
            {
                cost += 3;
            }

            cost = cost + shaft * 0.05f;

            Console.WriteLine($"Your total for this arrow comes to {cost} gold pieces.");
        }
        public void Build()
        {

            shaft = AskforValue("Length of arrow shaft in Centimeters (between 60 and 100): ", 60, 100);

            int head = headMenu();
            if (head == 1)
            {
                aHead = arrowHead.steel;
            }
            else if (head == 2)
            {

                aHead = arrowHead.wood;

            }
            else
            {
                aHead = arrowHead.obsidian;
            }

            int feather = tailMenu();
            if (feather == 1)
            {
                tail = fletching.plastic;
            }
            else if (feather == 2)
            {
                tail = fletching.t_feathers;
            }
            else
            {
                tail = fletching.g_feathers;
            }

        }

        public int headMenu()
        {
            int choice;
            while (true)
            {

                Console.WriteLine("Arrow heads avaible:");
                Console.WriteLine("1.   Steel");
                Console.WriteLine("2.   Wood");
                Console.WriteLine("3.   Obsidian");
                Console.Write("Enter the number of what you want: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice > 0 && choice < 4)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Sorry, we don't sell that.");
                }

            }

        }

        public int tailMenu()
        {
            int choice;

            while (true)
            {
                Console.WriteLine("Fletching Avaible:");
                Console.WriteLine("1.   Plastic");
                Console.WriteLine("2.   Turkey Feathers");
                Console.WriteLine("3.   Goose Feathers");
                Console.Write("Enter the number of what you want: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice > 0 && choice < 4)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Sorry, we don't sell that.");
                }
            }



        }
    }

    public static int AskforValue(string text, int min, int max) 
    {
        int value;


        while (true)
        {

            Console.Write(text);
            value = Convert.ToInt32(Console.ReadLine());

            if (value >= min && value <= max)
            {

                return value;

            }
            else 
            {
                    Console.WriteLine("That value is out of range, try again.");
            }
        }
    
    }

    
}