using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Admin.Commands;
using TaskManagement.Common;
using TaskManagement.Database;
using TaskManagement.Database.Models;

namespace TaskManagement.Database
{
    public static class DataContext
    {
        private static List<User> users = new List<User>();

        public static IEnumerable<Message> Messages { get; internal set; }
        public static string Setting { get; internal set; }

        public static List<User> GetAllUsers()
        {
            return users;
        }

        public static User GetUserById(int id)
        {
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        internal static User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}


namespace TaskManagement.Admin.Commands
{
    public class ShowUsersCommand
    {
        public static void Handle()
        {
            int order = 1;

            foreach (User user in DataContext.Users)
            {
                Console.WriteLine($"{order}. {user.GetShortInfo()}");
                order++;
            }
        }
    }
    public class ShowUserByEmailCommand
    {
        public static void Handle()
        {
            Console.Write("Enter email address: ");
            string email = Console.ReadLine()!;

            User user = DataContext.GetUserByEmail(email);

            if (user != null)
            {
                Console.WriteLine(user.GetFullInfo());
            }
            else
            {
                Console.WriteLine($"User with email address {email} not found.");
            }
        }
    }
    public class UpdateSettingsCommand
    {
        public static void Handle()
        {
            Console.Write("Enter new setting value: ");
            string value = Console.ReadLine()!;
            DataContext.Setting = value;

            Console.WriteLine("System setting updated successfully.");
        }
    }

    public class DepromoteFromAdminCommand
    {
        public static object Role { get; private set; }

        public static void Handle()
        {
            Console.Write("Enter user ID: ");
            int id = int.Parse(Console.ReadLine()!);

            User user = DataContext.GetUserById(id);

            if (user != null)
            {
                if (user.Role != Role.Admin)
                {
                    Console.WriteLine($"User {user.Name} is not an admin.");
                }
                else
                {
                    user.Role = Role.User;
                    Console.WriteLine($"User {user.Name} demoted from admin successfully.");
                }
            }
            else
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
        }
    }

    public class RemoveUserCommand
    {
        public static void Handle()
        {
            Console.WriteLine("Enter the user's email:");
            string email = Console.ReadLine()!;

            User userToRemove = null;

            foreach (User user in DataContext.Users)
            {
                if (user.Email == email)
                {
                    userToRemove = user;
                    break;
                }
            }

            if (userToRemove == null)
            {
                Console.WriteLine($"User with email {email} not found");
                return;
            }

            DataContext.Users.Remove(userToRemove);

            Console.WriteLine(userToRemove.GetShortInfo());
        }
    }

    public class BanUserCommand
    {
        public static void Handle()
        {
            Console.WriteLine("Enter the user's email:");
            string email = Console.ReadLine()!;

            User userToBan = null;

            foreach (User user in DataContext.Users)
            {
                if (user.Email == email)
                {
                    userToBan = user;
                    break;
                }
            }

            if (userToBan == null)
            {
                Console.WriteLine($"User with email {email} not found");
                return;
            }

            userToBan.IsBanned = true;

            Console.WriteLine($"User {userToBan.GetShortInfo()} has been banned from the system.");
        }
    }

    public class MessageToCommand
    {
        public static void Handle()
        {
            Console.WriteLine("Enter recipient email:");
            string recipientEmail = Console.ReadLine()!;
            User recipient = null;
            foreach (User user in DataContext.Users)
            {
                if (user.Email == recipientEmail)
                {
                    recipient = user;
                    break;
                }
            }

            if (recipient == null)
            {
                Console.WriteLine($"User with email '{recipientEmail}' not found. Please try again.");
                return;
            }

            Console.WriteLine("Enter message:");
            string message = Console.ReadLine()!;

            Console.WriteLine("Message sent successfully.");
        }
    }

    public class CloseAccountCommand
    {
        public static void Handle(User currentUser)
        {
            Console.WriteLine("Please enter your password to close your account:");

            string password = Console.ReadLine()!;

            if (currentUser.Password != password)
            {
                Console.WriteLine("Invalid password. Account closed.");
                return;
            }

            DataContext.Users.Remove(currentUser);
            Console.WriteLine("Account has been successfully closed.");
        }
    }

    public class ShowAllMessagesCommand
    {
        public static void Handle()
        {
            int order = 1;

            foreach (Message message in DataContext.Messages)
            {
                Console.WriteLine($"{order}. {message.GetShortInfo()}");
                order++;
            }
        }
    }

}
