using TaskManagement.Database.Models;

namespace TaskManagement.Database
{
    public class DataContext
    {
        public static List<User> Users { get; set; } = new List<User>();

        static DataContext()
        {
            AddUserSeeedings();
        }

        public DataContext()
        {
            AddUserSeeedings();
        }

        private static void AddUserSeeedings()
        {
            Users.Add(new User("Super", "Admin", "123321", "admin@gmail.com", true));
        }
    }
}
