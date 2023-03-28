using BloggerDomain.Entities;

namespace BloggerTests.Unit
{
    public class BlogTests
    {
        [Fact]
        public void CanNotHaveFutureCreatedDate()
        {
            var blog = new Blog();
            Assert.Throws<ArgumentOutOfRangeException>(() => blog.Created = DateTime.Now.AddMilliseconds(1));
        }
    }
}