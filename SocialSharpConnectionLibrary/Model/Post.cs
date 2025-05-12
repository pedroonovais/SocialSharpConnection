namespace library.Model
{
    public class Post
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Author { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Post() { }

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

        public long GetId() => Id;

        public void Exibir()
        {
            Console.WriteLine(this);
        }
    }
}