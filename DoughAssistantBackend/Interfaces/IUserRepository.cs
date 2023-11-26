using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface IUserRepository : IRepository
    {
        ICollection<User> GetUsers();
        User GetUser(string userId);
        bool UserExists(string userId);
        bool CreateUser(User user);
        
        // post userconfig
        // get userconfig
        // update userconfig
        
        
        // post month currency
        // get month currency
        // update month currency
    }
}