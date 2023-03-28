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
    public class DomainDataAccess
    {

        [Fact]
        public void TestUpdateBlog() 
        {
            var mockRepository = new Mock<IBlogRepository>();
            mockRepository.Setup(r => new MockBloggingRepository());

            var domain = new BlogService(mockRepository.Object);
            
        }
    }
}
