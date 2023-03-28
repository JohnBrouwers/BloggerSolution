using BloggerDomain.Entities;
using BloggerDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerDomain.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Blog GetBlog(int blogId)
        {

            return _blogRepository.GetBlog(blogId);
        }

        public ICollection<Blog> GetAll()
        {
            return _blogRepository.GetBlogs();
        }

        public bool UpdateBlog(int authorId, Blog blog)
        {
            if (authorId != blog.AuthorId)
            {
                throw new InvalidOperationException("Author does not match");
            }
            Blog repositoryBlog = GetBlog(blog.Id);

            if (!repositoryBlog.AuthorId.Equals(authorId))
            {
                throw new InvalidOperationException("Invalid Blog Author");
            }

            return _blogRepository.Update(blog);
        }
    }
}
