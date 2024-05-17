namespace Task5
{
    internal class Task5
    {
        static void Main(string[] args)
        {
            #region TASK 5 - Password Validation

            /* Task 5: Password Validation
            Write a program that prompts the user to create a password for their bank account.Implement if
            conditions to validate the password according to these rules:
                • The password must be at least 8 characters long.
                • It must contain at least one uppercase letter.
                • It must contain at least one digit.
                • Display appropriate messages to indicate whether their password is valid or not. */

            while (true)
            {
                Console.WriteLine("--- Create New Password --- \n");
                Console.WriteLine("Enter your password :: ");
                string password = Console.ReadLine();

                if (password.Length >= 8)
                {
                    if (password.Any(char.IsUpper) & password.Any(char.IsDigit))
                    {
                        Console.WriteLine("New Password set successfully!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password, Retry!");
                        Console.WriteLine("Ensure your password contains atleast one uppercase letter and atleast one digit");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Password, Retry!");
                    Console.WriteLine("Your password must be atleast 8 characters long");
                }
            }
            #endregion
        }
    }
}
