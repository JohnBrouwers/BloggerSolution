namespace BloggerDomain.Entities
{
    public class Blog
    {
        private DateTime _created;

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public DateTime Created
        {
            get
            { 
                return _created; 
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("A blog can't have a future creation date");
                }
                _created = value;
            }
        }
    }
}