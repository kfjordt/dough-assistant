using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUser(string email);
        bool UserExists(int id);
        bool UserExists(string email);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}