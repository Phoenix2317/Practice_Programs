using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {

        Arrow sell = new Arrow();
        sell.Build();
        Console.WriteLine($"Your arrow costs {sell.Cost} gold pieces.");

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

        private arrowHead aHead;
        private fletching tail;
        private int shaft;

        public arrowHead Tip 
        {
            get => aHead;
            set => aHead = value;
        }

        public fletching Tail
        {
            get => tail;
            set => tail = value;
        }

        public int Shaft
        {
            get => shaft;
            set => shaft = value;
        }

        public float Cost
        {

            get
            {
                float cost = 0;
                switch (Tip)
                {
                    case arrowHead.obsidian:
                        cost += 5;
                        break;
                    case arrowHead.wood:
                        cost += 3;
                        break;
                    case arrowHead.steel:
                        cost += 10;
                        break;
                    default:
                        break;
                }

                switch (Tail)
                {
                    case fletching.plastic:
                        cost += 10;
                        break;
                    case fletching.t_feathers:
                        cost += 5;
                        break;
                    case fletching.g_feathers:
                        cost += 3;
                        break;
                    default:
                        break;

                }

                cost += (shaft * 0.05f);
                return cost;

            }

        }

        public void Build()
        {

            Shaft = AskforValue("Length of arrow shaft in Centimeters (between 60 and 100): ", 60, 100);

            Tip = headMenu();

            Tail = tailMenu();
            

        }
        private arrowHead headMenu()
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

                switch (choice)
                {
                    case 1:
                        return arrowHead.steel;
                        
                    case 2:
                        return arrowHead.wood;
                       
                    case 3:
                        return arrowHead.obsidian;
                        
                    default:
                        Console.WriteLine("Sorry, we don't sell that.");
                        break;
                }
                
                   
                

            }

            

        }
        private fletching tailMenu()
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

               switch (choice)
               {

                    case 1:
                        return fletching.plastic;
                    case 2:
                        return fletching.t_feathers;
                    case 3:
                        return fletching.g_feathers;
                    default:
                        Console.WriteLine("Sorry, we don't sell that.");
                        break;

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