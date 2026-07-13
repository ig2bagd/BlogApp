namespace BlazingBlog;

public interface IBlogRepository
{
    Task<List<BlogPost>> GetPosts();
    Task<BlogPost> GetPost(int id);
    Task AddPost(string title, string content);
    Task UpdatePost(BlogPost post);
    Task DeletePost(int id);
}
