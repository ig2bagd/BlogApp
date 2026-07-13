using Microsoft.Extensions.Hosting;

namespace BlazingBlog;

public class BlogRepository : IBlogRepository
{
    private List<BlogPost> blogPosts = new List<BlogPost>
                {
                    new BlogPost { Id = 1, Title = "First post", Content = "This is the first post"},
                    new BlogPost { Id = 2, Title = "Second post", Content = "This is the second post"},
                    new BlogPost { Id = 3, Title = "Third post", Content = "This is the third post"}
                };

    public Task<List<BlogPost>> GetPosts() => Task.FromResult(blogPosts);

    public Task<BlogPost> GetPost(int id) => Task.FromResult(blogPosts.First(p => p.Id == id));

    public Task AddPost(string title, string content)
    {
        var newId = blogPosts.Count() != 0 ? blogPosts.Max(post => post.Id) + 1 : 0;
        var newPost = new BlogPost { Id = newId, Title = title, Content = content };
        return Task.Run(() => blogPosts.Add(newPost));
    }

    public Task DeletePost(int id) => throw new NotImplementedException();

    public Task UpdatePost(BlogPost post) => throw new NotImplementedException();
}
