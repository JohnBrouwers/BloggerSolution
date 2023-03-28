using BloggerDomain.Entities;
using BloggerDomain.Repositories;
using BloggerDomain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerTests.Integration
{
    /// <summary>
    /// Deze test classe is een integratie test die een mock aanmaakt voor de BlogRepository
    /// De mock vervangt nu Entity Framework ofwel de interactie met de database is nu niet nodig
    /// </summary>
    public class BlogServiceMockRepository
    {
        private readonly IBlogRepository MockBlogRepository;

        public BlogServiceMockRepository()
        {
            //Dit is de data die we voor als mock gebruiken om de data access laag te vervangen met met een mock
            IList<Blog> blogs;
            Author authorBernd = new Author() { Id = 1, Firstname = "Bernd", Surname = "Berndson", Email = "bernd.berndson@mail.dk" };
            Author authorHilda = new Author() { Id = 2, Firstname = "Hilda", Surname = "Hildadottir", Email = "hilda.hildadottir@mail.dk" };
            Blog blogBernd = new Blog() { Id = 1, Title = "Bernds first blog title", Content = "Bernds first blog content", AuthorId = authorBernd.Id };
            Blog blog1Hilda = new Blog() { Id = 2, Title = "Hilda first blog title", Content = "Hilda first blog content", AuthorId = authorHilda.Id };
            Blog blog2Hilda = new Blog() { Id = 3, Title = "Hilda second blog title", Content = "Hilda second blog content", AuthorId = authorHilda.Id };
            blogs = new List<Blog>() { blogBernd, blog1Hilda, blog2Hilda };


            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            
            //GetBlogs mocken
            mock.Setup(mbr => mbr.GetBlogs()).Returns(blogs);

            //GetBlog mocken
            mock.Setup(mbr => mbr.GetBlog(It.IsAny<int>())).Returns((int i) => blogs.Where(b => b.Id == i).Single());

            //Create mocken
            mock.Setup(mbr => mbr.Create(It.IsAny<Blog>())).Returns((Blog blogToCreate) =>
            {
                blogToCreate.Id = blogs.Count + 1;
                blogs.Add(blogToCreate);
                return true;
            });

            //Update mocken
            mock.Setup(mbr => mbr.Update(It.IsAny<Blog>())).Returns((Blog blog) =>
            {
                var blogToUpdate = blogs.Where(b => b.Id == blog.Id).FirstOrDefault();
                if (blogToUpdate == null)
                {
                    return false;
                }
                blogToUpdate.Title = blog.Title;
                blogToUpdate.Content = blog.Content;
                return true;
            });

            //Delete mocken
            mock.Setup(mbr => mbr.Delete(It.IsAny<Blog>())).Returns((Blog blog) => { 
                var blogToDelete = blogs.Where(b => b.Id == blog.Id).FirstOrDefault();
                if (blogToDelete == null)
                {
                    return false;
                }
                blogs.Remove(blogToDelete);
                return true;
            });

            //Toestaan dat alle tests in deze klasse bij het mock object kunnen komen via het private field
            MockBlogRepository = mock.Object;
        }


        [Fact]
        public void CanGetBlog() 
        {
            var blogService = new BlogService(MockBlogRepository);

            var blogId = 1;
            var blog = blogService.GetBlog(blogId);
            Assert.NotNull(blog);
            Assert.IsType<Blog>(blog);
            Assert.True(blog.Id == blogId);
        } 

        [Fact]
        public void CanGetAllBlogs() 
        {
            var blogService = new BlogService(MockBlogRepository);

            var blogs = blogService.GetAll();
            Assert.NotNull(blogs);
            Assert.Equal(3, blogs.Count);
        } 

        [Fact]
        public void CanUpdateBlog() 
        {
            var blogService = new BlogService(MockBlogRepository);

            var authorId = 1;
            var authorBlog = blogService.GetAll().First(b => b.AuthorId == authorId);
            var success = blogService.UpdateBlog(authorId, authorBlog);

            Assert.True(success);
        }   

        [Fact]
        public void CanAuthorUpdateBlog() 
        {
            var blogService = new BlogService(MockBlogRepository);

            var authorId = 1;
            var authorBlog = blogService.GetAll().First(b => b.AuthorId == authorId);
            var success = blogService.UpdateBlog(authorId, authorBlog);

            Assert.True(success);
        }        
        
        [Fact]
        public void CanNonAuthorsNotUpdateBlog()
        {
            var blogService = new BlogService(MockBlogRepository);

            var authorId = 1;
            var nonAuthorId = 999;
            var authorBlog = blogService.GetAll().First(b => b.AuthorId == authorId);

            Assert.Throws<InvalidOperationException>(()=> blogService.UpdateBlog(nonAuthorId, authorBlog));
        }


    }
}
