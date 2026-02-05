using System;
using System.Linq;

namespace SocialMediaPostManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialMediaManager manager = new SocialMediaManager();

            Console.WriteLine("=== Social Media Post Management System ===\n");

            // Test Case 1: User registration
            Console.WriteLine("--- Registering Users ---");
            manager.RegisterUser("JohnDoe", "Software developer and tech enthusiast");
            manager.RegisterUser("JaneSmith", "Travel blogger exploring the world");
            manager.RegisterUser("BobWilson", "Food critic and chef");
            manager.RegisterUser("AliceJones", "Photography and art lover");
            manager.RegisterUser("CharlieBrown", "Fitness trainer and nutritionist");
            Console.WriteLine();

            // Get user IDs for creating posts
            var users = manager.GetAllUsers();
            var johnId = users[0].UserId;
            var janeId = users[1].UserId;
            var bobId = users[2].UserId;
            var aliceId = users[3].UserId;
            var charlieId = users[4].UserId;

            // Test Case 2: Create different types of posts
            Console.WriteLine("--- Creating Posts ---");
            manager.CreatePost(johnId, "Just finished building my new web application! Check it out!", "Text");
            manager.CreatePost(johnId, "Beautiful sunset coding session", "Image");
            manager.CreatePost(janeId, "Exploring the streets of Paris! Amazing architecture!", "Image");
            manager.CreatePost(janeId, "Top 10 travel destinations for 2026", "Video");
            manager.CreatePost(bobId, "Today's special: Homemade pasta with truffle sauce", "Image");
            manager.CreatePost(aliceId, "New photography exhibition opening next week!", "Text");
            manager.CreatePost(charlieId, "5 exercises for a stronger core", "Video");
            manager.CreatePost(bobId, "Review: The best Italian restaurant in town", "Text");
            Console.WriteLine();

            // Get post IDs for testing
            var posts = manager.GetAllPosts();

            // Test Case 3: Like and comment on posts
            Console.WriteLine("--- Liking and Commenting on Posts ---");
            manager.LikePost(posts[0].PostId, janeId);
            manager.LikePost(posts[0].PostId, bobId);
            manager.LikePost(posts[0].PostId, aliceId);
            manager.LikePost(posts[0].PostId, charlieId);
            manager.AddComment(posts[0].PostId, janeId, "Great work! Would love to see more details.");
            manager.AddComment(posts[0].PostId, bobId, "Impressive!");

            manager.LikePost(posts[2].PostId, johnId);
            manager.LikePost(posts[2].PostId, bobId);
            manager.LikePost(posts[2].PostId, aliceId);
            manager.LikePost(posts[2].PostId, charlieId);
            manager.LikePost(posts[2].PostId, janeId);
            manager.AddComment(posts[2].PostId, aliceId, "Beautiful shot! What camera did you use?");

            manager.LikePost(posts[4].PostId, johnId);
            manager.LikePost(posts[4].PostId, janeId);
            manager.LikePost(posts[4].PostId, aliceId);
            manager.AddComment(posts[4].PostId, johnId, "Looks delicious!");

            manager.LikePost(posts[6].PostId, johnId);
            manager.LikePost(posts[6].PostId, janeId);
            manager.AddComment(posts[6].PostId, janeId, "Thanks for the tips!");
            Console.WriteLine();

            // Test Case 4: Group posts by user
            Console.WriteLine("--- Grouping Posts by User ---");
            var groupedPosts = manager.GroupPostsByUser();
            foreach (var group in groupedPosts)
            {
                var user = manager.GetUser(group.Key);
                Console.WriteLine($"\n{user.UserName}'s Posts ({group.Value.Count} posts):");
                foreach (var post in group.Value)
                {
                    Console.WriteLine($"  - [{post.PostType}] {post.Content}");
                    Console.WriteLine($"    Likes: {post.Likes}, Comments: {post.Comments.Count}");
                }
            }
            Console.WriteLine();

            // Test Case 5: Find trending posts
            Console.WriteLine("--- Trending Posts (3+ likes) ---");
            var trendingPosts = manager.GetTrendingPosts(3);
            Console.WriteLine($"Found {trendingPosts.Count} trending post(s):");
            for (int i = 0; i < trendingPosts.Count; i++)
            {
                var post = trendingPosts[i];
                var user = manager.GetUser(post.UserId);
                Console.WriteLine($"\n{i + 1}. Post by {user.UserName}:");
                Console.WriteLine($"   Content: {post.Content}");
                Console.WriteLine($"   Type: {post.PostType}");
                Console.WriteLine($"   Likes: {post.Likes}");
                Console.WriteLine($"   Comments: {post.Comments.Count}");
                if (post.Comments.Count > 0)
                {
                    Console.WriteLine("   Recent Comments:");
                    foreach (var comment in post.Comments.Take(2))
                    {
                        Console.WriteLine($"     - {comment}");
                    }
                }
            }
            Console.WriteLine();

            // Summary
            Console.WriteLine("--- Platform Summary ---");
            Console.WriteLine($"Total Users: {users.Count}");
            Console.WriteLine($"Total Posts: {posts.Count}");
            Console.WriteLine($"Total Likes: {posts.Sum(p => p.Likes)}");
            Console.WriteLine($"Total Comments: {posts.Sum(p => p.Comments.Count)}");

            Console.WriteLine("\n=== End of Social Media Post Management Demo ===");
        }
    }
}
