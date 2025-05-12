using data.Context;
using library.Model;
using Microsoft.EntityFrameworkCore;

namespace service.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.GetName()) ||
                string.IsNullOrWhiteSpace(user.GetEmail()) ||
                string.IsNullOrWhiteSpace(user.GetUsername()))
                throw new ArgumentException("Name, email, and username are required.");

            if (user.GetAge() <= 0)
                throw new ArgumentException("Age must be greater than 0.");

            // Cria nova instância para garantir novo ID gerado corretamente
            var newUser = new User(user.GetId(), user.GetName(), user.GetAge(), user.GetEmail(), user.GetUsername());

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public bool Update(long id, User updatedUser)
        {
            var existingUser = GetById(id);
            if (existingUser == null)
                return false;

            if (string.IsNullOrWhiteSpace(updatedUser.GetName()) ||
                string.IsNullOrWhiteSpace(updatedUser.GetEmail()) ||
                string.IsNullOrWhiteSpace(updatedUser.GetUsername()) ||
                updatedUser.GetAge() <= 0)
                throw new ArgumentException("Invalid updated user data.");

            var newUser = new User(
                updatedUser.GetId(),
                updatedUser.GetName(),
                updatedUser.GetAge(),
                updatedUser.GetEmail(),
                updatedUser.GetUsername()
            );

            _context.Entry(existingUser).State = EntityState.Detached;
            _context.Users.Update(newUser);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var user = GetById(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
