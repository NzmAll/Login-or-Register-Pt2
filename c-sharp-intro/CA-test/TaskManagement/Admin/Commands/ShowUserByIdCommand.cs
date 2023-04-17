using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database;
using TaskManagement.Database.Models;

namespace TaskManagement.Admin.Commands
{
    public class ShowUserByIdCommand
    {
        public static void Handle()
        {
            while (true)
            {
                try
                {
                    int id = int.Parse(Console.ReadLine()!);

                    foreach (User user in DataContext.Users)
                    {
                        if (user.Id == id)
                        {
                            Console.WriteLine(user.GetShortInfo());
                            return;
                        }
                    }

                    Console.WriteLine("Email not found");
                }
                catch 
                {
                    Console.WriteLine("Invalid input pls try again");
                }
            }

        }
    }
}
