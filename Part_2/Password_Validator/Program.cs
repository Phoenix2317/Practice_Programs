using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        // This is a simple password generator that checks for the following rules:
        bool stop = false;
        Password pass = new Password();
        string NewPass = "";

        // Rules for the password
        Console.WriteLine("Make a password that is 6 chars at least and 13 at most");
        Console.WriteLine("Password needs 1 uppercase, 1 lowercase, and at least 1 number");
        Console.WriteLine("Password cannot have a capital T or a &. This is because of IT");

        do // Loop until the user enters a valid password
        {
            Console.Write("Enter a new Password: ");
            NewPass = Console.ReadLine();

            if (Password.ruleCheck(NewPass)) // Check if the password is valid
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

    // Password class that checks for the rules of the password
    public class Password
    {
        // Property to hold the password
        public string pass {  get; private set; }

        // Default constructor that initializes the password to a default value
        public Password()
        {

            pass = "------";

        }

        /**
         * Initializes a new instance of the Password class with the specified password.
         * @param pass The password to be set.
         */
        public Password(string pass)
        {
            bool correct = false;

            do // Loop until the user enters a valid password
            {
                if (pass != null) // Check if the password is not null
                {

                    if (ruleCheck(pass)) // Check if the password is valid
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

        /**
         * Changes the password to the specified value if it meets the rules.
         * @param pass The new password to be set.
         */
        public void ChangePassword(string pass)
        {
            if(ruleCheck(pass))
            {
                this.pass = pass;
            } else { Console.WriteLine("Invalid, try again"); }
        }

        /**
         * Checks if the specified password meets the rules.
         * @param password The password to be checked.
         * @returns True if the password is valid; otherwise, false.
         */
        public static bool ruleCheck(string password)
        {
            int upper = 0;
            int lower = 0;
            int num = 0;

            // Check if the password length is between 6 and 13 characters
            if (password.Length >= 6 && password.Length <= 13)
            {
                // Iterate through each character in the password and count the number of uppercase, lowercase, and numeric characters
                foreach (char c in password) 
                {
                    // Check if the character is uppercase, lowercase, or numeric and increment the corresponding counter
                    if (char.IsUpper(c)) {  upper++; }
                    else if (char.IsLower(c)) { lower++; }
                    else if(char.IsDigit(c)) { num++; }

                    if (c.Equals('T') || c.Equals('&')) { return false; }

                }
                // Return true if the password has at least one uppercase, one lowercase, and one numeric character; otherwise, return false
                if (upper > 0 && lower > 0 && num > 0) { return true; }
                else { return false; }

            } else {  return false; }
        }
    }

}