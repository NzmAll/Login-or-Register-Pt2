namespace NewLesson
{
    public static class Test
    {

    }

    public class User
    {
        public static int _idCounter;


        static User()
        {
            Console.WriteLine("Intor");
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public User(string name, string lastName, string password, string email, bool isAdmin = false)
        {
            Id = ++_idCounter;
            Name = name;
            LastName = lastName;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
        }

        public static void Print()
        {
            Console.WriteLine("hELLO WORLD");
            
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 20;


            User firstUser = new User("Mahmood", "Garibov", "qaribov@gmail.com", "12331");
            User.Print();
            User.Print();
            User.Print();
            User.Print();
            User.Print();



            firstUser = new User("Eldar", "Vagif", "qaribov3@gmail.com", "12331"); 

        

            //User thirdUser = new User("Eldar", "Vagif", "qaribov3@gmail.com", "12331");

        }
    }
}