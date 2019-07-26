using Blog.Models.Entities;
using System.Collections.Generic;

namespace Blog.Services
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostsByDate(int year, int month);
        Post GetPost(string slug);
    }
}
