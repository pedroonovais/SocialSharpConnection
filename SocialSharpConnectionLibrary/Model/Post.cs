namespace library.Model
{
    public class Post
    {
        public long Id { get; }
        public long IdUser { get; }
        public string Author { get; }
        public string Username { get; }
        public string Content { get; }
        public DateTime Date { get; }

        public Post(long id, long idUser, string author, string username, string content, DateTime date)
        {
            Id = id;
            IdUser = idUser;
            Author = author;
            Username = username;
            Content = content;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Author} ({Username}) ({Date:dd/MM/yyyy HH:mm})\n{Content}";
        }
    }
}
