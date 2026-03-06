using System.ComponentModel.DataAnnotations;

namespace nexus2.Models
{
    public enum PostType { Text, Image, Video }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Follow>? Followers { get; set; }
        public ICollection<Follow>? Following { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? MediaUrl { get; set; }
        public PostType Type { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string? AiSummary { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }

    public class Follow
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public User? Follower { get; set; }
        public int FollowingId { get; set; }
        public User? Following { get; set; }
    }

    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}