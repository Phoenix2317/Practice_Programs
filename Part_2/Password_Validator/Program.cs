using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        bool stop = false;
        Password pass = new Password();
        string NewPass = "";
        Console.WriteLine("Make a password that is 6 chars at least and 13 at most");
        Console.WriteLine("Password needs 1 uppercase, 1 lowercase, and at least 1 number");
        Console.WriteLine("Password cannot have a capital T or a &. This is because of IT");
        
        do
        {
            Console.Write("Enter a new Password: ");
            NewPass = Console.ReadLine();

            if (Password.ruleCheck(NewPass))
            {
                pass.ChangePassword(NewPass);
                stop = true;
            } else 
            {
                stop = false;
                Console.WriteLine("Invalid");
            }
            

        } while (!stop);

    }

    public class Password
    {

        public string pass {  get; private set; }

        public Password()
        {

            pass = "------";

        }
        public Password(string pass)
        {
            bool correct = false;

            do
            {
                if (pass != null)
                {

                    if (ruleCheck(pass))
                    {
                        this.pass = pass;
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password, try again");
                    }

                }
                else
                {

                    Console.WriteLine("Invalid Password, try again");

                }
            } while (!correct);
        }

        public void ChangePassword(string pass)
        {
            if(ruleCheck(pass))
            {
                this.pass = pass;
            } else { Console.WriteLine("Invalid, try again"); }
        }

        public static bool ruleCheck(string password)
        {
            int upper = 0;
            int lower = 0;
            int num = 0;

            if(password.Length >= 6 && password.Length <= 13)
            {

                foreach (char c in password) 
                {

                    if (char.IsUpper(c)) {  upper++; }
                    else if (char.IsLower(c)) { lower++; }
                    else if(char.IsDigit(c)) { num++; }

                    if (c.Equals('T') || c.Equals('&')) { return false; }

                }
                
                if (upper > 0 && lower > 0 && num > 0) { return true; }
                else { return false; }

            } else {  return false; }
        }
    }

}