using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public User GetByEmail(string email);
    public User GetByUsername(string username);
}