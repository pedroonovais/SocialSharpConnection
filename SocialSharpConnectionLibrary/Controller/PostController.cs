using library.model;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace library.Controller
{
    public static class PostController
    {
        
        public static List<Post> CarregarPosts()
        {
            return new List<Post> {
                new Post(1, 1, "João", "joao123", "Bom dia, galera!", new DateTime(2025, 3, 15, 21, 12, 0, DateTimeKind.Local)),
                new Post(2, 2, "Maria", "maria123", "Alguém assistiu o novo filme da Marvel?", new DateTime(2025, 3, 14, 22, 1, 0, DateTimeKind.Local)),
                new Post(3, 3, "José", "jose123", "Sem duvidas, o Neymar traiu o Brasil!", new DateTime(2025, 3, 13, 10, 12, 0, DateTimeKind.Local)),
                new Post(4, 4, "Ana", "ana123", "O Palmeiras venceu o Flamengo?", new DateTime(2025, 3, 12, 7, 2, 0, DateTimeKind.Local))
            };
        }

        public static void CriarPost(ref List<Post> posts, User user, string content)
        {
            var novoPost = PostFactory.CriarNovoPost(posts.Max(post => post.GetId()) + 1, user.GetId(), user.GetName(), user.GetUsername(), content);
            posts.Add(novoPost);
        }
    }

    file static class PostFactory
    {
        public static Post CriarNovoPost(long id, long userId, string name, string username, string content)
        {
            return new Post(
                id: id,
                idUser: userId,
                author: name,
                username: username,
                content: content,
                date: DateTime.Now
            );
        }
    }
}
