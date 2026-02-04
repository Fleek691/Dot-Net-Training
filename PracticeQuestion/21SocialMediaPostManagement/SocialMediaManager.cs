using System;
using System.Collections.Generic;

namespace SocialMediaPostManagement
{
    public class SocialMediaManager
    {
        public void RegisterUser(string userName, string bio)
        {
        }

        public void CreatePost(string userId, string content, string type)
        {
        }

        public void LikePost(string postId, string userId)
        {
        }

        public void AddComment(string postId, string userId, string comment)
        {
        }

        public Dictionary<string, List<Post>> GroupPostsByUser()
        {
            return null;
        }

        public List<Post> GetTrendingPosts(int minLikes)
        {
            return null;
        }
    }
}
