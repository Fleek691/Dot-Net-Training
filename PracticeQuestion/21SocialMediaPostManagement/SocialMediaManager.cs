using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaPostManagement
{
    public class SocialMediaManager
    {
        private List<User> users = new List<User>();
        private List<Post> posts = new List<Post>();
        private Random random = new Random();

        public void RegisterUser(string userName, string bio)
        {
            string userId = "USER" + random.Next(1000, 9999);
            var user = new User
            {
                UserId = userId,
                UserName = userName,
                Bio = bio,
                FollowersCount = 0,
                Following = new List<string>()
            };
            users.Add(user);
            Console.WriteLine($"User registered: {userName} (ID: {userId})");
        }

        public void CreatePost(string userId, string content, string type)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            string postId = "POST" + random.Next(10000, 99999);
            var post = new Post
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                PostTime = DateTime.Now,
                PostType = type,
                Likes = 0,
                Comments = new List<string>()
            };
            posts.Add(post);
            Console.WriteLine($"Post created by {user.UserName}: {postId}");
        }

        public void LikePost(string postId, string userId)
        {
            var post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            post.Likes++;
            Console.WriteLine($"{user.UserName} liked post {postId}. Total likes: {post.Likes}");
        }

        public void AddComment(string postId, string userId, string comment)
        {
            var post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            post.Comments.Add($"{user.UserName}: {comment}");
            Console.WriteLine($"{user.UserName} commented on post {postId}");
        }

        public Dictionary<string, List<Post>> GroupPostsByUser()
        {
            return posts.GroupBy(p => p.UserId)
                       .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Post> GetTrendingPosts(int minLikes)
        {
            return posts.Where(p => p.Likes >= minLikes)
                       .OrderByDescending(p => p.Likes)
                       .ToList();
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public List<Post> GetAllPosts()
        {
            return posts;
        }

        public User GetUser(string userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        public Post GetPost(string postId)
        {
            return posts.FirstOrDefault(p => p.PostId == postId);
        }
    }
}
