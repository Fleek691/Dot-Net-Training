

    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public abstract class User2
    {
        string type{get;set;}
        string name{get;set;}
        Gender gender{get;set;}
        int age{get;set;}
        public User2(string Type,string Name,Gender Gender,int Age)
        {
            type=Type;
            name=Name;
            gender=Gender;
            age=Age;
        }
        public string GetUserName()
        {
            return name;
        }
        public new string  GetType()
        {
            return type;
        }
        public int GetAge()
        {
            return age;
        }
        public Gender GetGender()
        {
            return gender;
        }

    }
    public class Admin : User2
    {
        public Admin(string name,Gender gender,int age): base("Admin", name, gender, age)
        {
            
        }
    }
    public class Moderator : User2
    {
        public Moderator(string name,Gender gender,int age): base("Moderator", name, gender, age)
        {
            
        }
    }

    class Ques11
    {
        static void Main()
        {
            // Create Admin user
            User2 admin = new Admin("Rahul", Gender.Male, 30);

            Console.WriteLine("Admin Details:");
            Console.WriteLine("Name: " + admin.GetUserName());
            Console.WriteLine("Age: " + admin.GetAge());
            Console.WriteLine("Gender: " + admin.GetGender());
            Console.WriteLine("Type: " + admin.GetType());
            Console.WriteLine();

            // Create Moderator user
            User2 moderator = new Moderator("Anita", Gender.Female, 25);

            Console.WriteLine("Moderator Details:");
            Console.WriteLine("Name: " + moderator.GetUserName());
            Console.WriteLine("Age: " + moderator.GetAge());
            Console.WriteLine("Gender: " + moderator.GetGender());
            Console.WriteLine("Type: " + moderator.GetType());
        }
    }

