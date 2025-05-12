using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Context;
using library.Model;
using Microsoft.EntityFrameworkCore;

namespace service.Services
{
    public class PostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(long id)
        {
            return _context.Posts.Find(id);
        }

        public Post Create(Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Content))
                throw new ArgumentException("Post content cannot be empty.");

            if (string.IsNullOrWhiteSpace(post.Author) || string.IsNullOrWhiteSpace(post.Username))
                throw new ArgumentException("Author and username are required.");

            post = new Post(post.GetId(), post.IdUser, post.Author, post.Username, post.Content, DateTime.Now);

            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public bool Update(long id, Post updatedPost)
        {
            var existingPost = GetById(id);
            if (existingPost == null)
                return false;

            if (string.IsNullOrWhiteSpace(updatedPost.Content))
                throw new ArgumentException("Post content cannot be empty.");

            var newPost = new Post(id, existingPost.IdUser, updatedPost.Author, updatedPost.Username, updatedPost.Content, DateTime.Now);

            _context.Entry(existingPost).State = EntityState.Detached;
            _context.Posts.Update(newPost);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var post = GetById(id);
            if (post == null)
                return false;

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return true;
        }
    }
}
