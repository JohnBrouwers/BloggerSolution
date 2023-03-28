using BloggerDomain.Entities;
using BloggerDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerTests.Integration
{
    internal class MockBloggingRepository : IBlogRepository
    {
        private ICollection<Blog> blogs;
        private ICollection<Author> authors;

        public MockBloggingRepository()
        {
            Author authorBernd= new Author() { Id=1, Firstname = "Bernd", Surname="Berndson", Email="bernd.berndson@mail.dk" };
            Blog blogBernd = new Blog() {Id = 1, Title = "Bernds first blog title" , Content = "Bernds first blog content", AuthorId = authorBernd.Id };

            blogs = new List<Blog>() { blogBernd };
            authors = new List<Author>() {authorBernd };
        }



        public bool Create(Blog blog)
        {
            blogs.Add(blog);
            return true;
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
