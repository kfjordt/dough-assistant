using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(user => user.Id == id).FirstOrDefault();    
        }

        public User GetUser(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(user => user.Email == email);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
    }
}