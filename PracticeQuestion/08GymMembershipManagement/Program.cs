using System;
using System.Linq;

class Program3
{
    static void Main()
    {
        GymManager gym = new GymManager();

        // Add members
        gym.AddMember("Alice", "Gold", 12);
        gym.AddMember("Bob", "Silver", 6);
        gym.AddMember("Charlie", "Gold", 12);
        gym.AddMember("Diana", "Premium", 24);

        // Add fitness classes
        gym.AddClass("Yoga", "John", DateTime.Now.AddDays(2), 20);
        gym.AddClass("Zumba", "Maria", DateTime.Now.AddDays(3), 30);
        gym.AddClass("Pilates", "Sarah", DateTime.Now.AddDays(1), 15);
        gym.AddClass("Boxing", "Mike", DateTime.Now.AddDays(5), 25);

        // Register members for classes
        bool registered = gym.RegisterForClass(1, "Yoga");
        Console.WriteLine($"Alice registered for Yoga: {registered}");

        registered = gym.RegisterForClass(2, "Zumba");
        Console.WriteLine($"Bob registered for Zumba: {registered}");

        registered = gym.RegisterForClass(3, "Pilates");
        Console.WriteLine($"Charlie registered for Pilates: {registered}");

        // Group members by membership type
        var groupedMembers = gym.GroupMembersByMembershipType();
        Console.WriteLine("\n--- Members by Membership Type ---");
        foreach (var group in groupedMembers)
        {
            Console.WriteLine($"\n{group.Key} Members:");
            foreach (var member in group.Value)
            {
                Console.WriteLine($"  - {member.Name} (Expires: {member.ExpiryDate:yyyy-MM-dd})");
            }
        }

        // Get upcoming classes
        var upcomingClasses = gym.GetUpcomingClasses();
        Console.WriteLine("\n--- Upcoming Classes (Next 7 Days) ---");
        foreach (var fitnessClass in upcomingClasses)
        {
            Console.WriteLine($"\n{fitnessClass.ClassName}:");
            Console.WriteLine($"  Instructor: {fitnessClass.Instructor}");
            Console.WriteLine($"  Schedule: {fitnessClass.Schedule:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"  Registered: {fitnessClass.RegisteredMembers.Count}/{fitnessClass.MaxParticipants}");
            if (fitnessClass.RegisteredMembers.Count > 0)
            {
                Console.WriteLine($"  Members: {string.Join(", ", fitnessClass.RegisteredMembers)}");
            }
        }
    }
}