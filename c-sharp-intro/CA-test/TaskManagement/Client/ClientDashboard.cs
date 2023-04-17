using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database.Models;

namespace TaskManagement.Client
{
    public class ClientDashboard
    {
        public static void Introduction(User user)
        {
            Console.WriteLine($"Hello! : {user.Email} {user.Password}");

        }
    }
}
