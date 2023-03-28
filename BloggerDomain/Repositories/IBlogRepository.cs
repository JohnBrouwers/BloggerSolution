using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggerDomain.Entities;

namespace BloggerDomain.Repositories
{
    public interface IBlogRepository
    {
        public bool IsAuthorBlogOwner(int authorId, int blogId);

        public Blog? GetBlog(int blogId);

        public ICollection<Blog> GetBlogs();

        public bool Create(Blog blog);

        public bool Update(Blog blog);

        public bool Delete(Blog blog);
    }
}
