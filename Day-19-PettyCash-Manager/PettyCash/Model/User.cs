using PettyCash.Enums;
namespace PettyCash.Model
{
    public abstract class User
    {
        public int Id{get;protected set;}
        public string Name{get;protected set;}
        public UserRole Role{get;protected set;}
        

    }
}
