using System.Text.RegularExpressions;
namespace Mod1RegularExpressiondemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        input:
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();
            if (ContainsDigits(name))
            {
                // If this name contains digit, we'll provide error mesesage
                Console.WriteLine("Name should not contain digits please enter name again.");
                goto input; // Go to the loop again SHEEEE thats neat!
                // Not the best practice because this could lead to multiple cases?
            }
            else
            {
            emailinput:
                Console.WriteLine("{0}, please enter your email", name);
                //position parameter. 
                //Instead of dollar sign, this string has some parameter, and we'll provide the parameter later.
                var email = Console.ReadLine();
                if (CheckEmail(email)) // If the email is validated as proper email
                {
                    Console.WriteLine($"Welcome {name}, you are registered with email {email}");
                }
                else
                {
                    Console.WriteLine("Invalid email format, please enter email again.");
                    goto emailinput; // Send them back!
                }

            }




            // It has to be static if we're calling directly unless its being called to an instance.
            // ESP if they're all in main or program.cs
            static bool CheckEmail(string email)
            {
                // now we'll use regex to check if the input was indeed an email (helper function)
                // These were taught in theory of computer science
                // Regex is very vast just find one as you need to use them.
                // @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
                // These can also come from textbox not just a console
                string emailpattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailpattern); // Input is first, then email pattern (what we check) is second
            }
            static bool ContainsDigits(string name)
            {
                // return name.Any(char.IsDigit);// If any of the char is digit, it'll return true
                // We will use regex class
                return Regex.IsMatch(name, @"\d");
            }
        }
    }
} 