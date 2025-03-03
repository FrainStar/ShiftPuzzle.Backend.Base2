namespace UserManagment.Interfaces;
using UserManagment.Models;

public interface IUserManager
{
    void AddUser(User user);
    void DeleteUser(Guid userId);
    User? GetUser(Guid userId);
    IEnumerable<User> GetAllUsers();
}