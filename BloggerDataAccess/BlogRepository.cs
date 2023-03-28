using BloggerDomain;
using BloggerDomain.Entities;
using BloggerDomain.Repositories;

namespace BloggerDataAccess
{
    public class BlogRepository : IBlogRepository
    {
        public BlogRepository()
        {

        }

        public bool Create(Blog blog)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlog(int blogId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Blog> GetBlogs()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorBlogOwner(int authorId, int blogId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}