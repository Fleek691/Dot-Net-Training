using System.Collections.Generic;

namespace SocialMediaPostManagement
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int FollowersCount { get; set; }
        public List<string> Following { get; set; }
    }
}
