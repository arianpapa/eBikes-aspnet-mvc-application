using eBikes.Models;

namespace eBikes.Data.Repositories
{
   public interface IBlogsRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Blog GetBlogById(int id);
        void Add(Blog blog);
        Blog Update(int id, Blog newBlog);
        void Delete(int id);
   }
}

