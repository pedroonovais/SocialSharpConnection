namespace library.Model
{
    public class Post : Publicacao
    {
        private protected long Id { get; }
        private protected long IdUser { get; }
        protected internal string Author { get; }
        protected internal string Username { get; }
        protected internal string Content { get; }
        protected internal DateTime Date { get; }

        public Post(long id, long idUser, string author, string username, string content, DateTime date)
            : base(id, idUser, content, date)
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

        public override void Exibir()
        {
            Console.WriteLine(this);
        }
    }
}
