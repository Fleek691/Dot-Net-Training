using System;
using System.Collections.Generic;

namespace SocialMediaPostManagement
{
    public class Post
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public string PostType { get; set; } // Text/Image/Video
        public int Likes { get; set; }
        public List<string> Comments { get; set; }
    }
}
