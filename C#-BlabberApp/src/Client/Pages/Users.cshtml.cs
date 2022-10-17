using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;
public class UsersModel : PageModel
{
    public IEnumerable<User> Users;
    private readonly ILogger<UsersModel> _log;
    private readonly IUserRepository _repo;
    public UsersModel(ILogger<UsersModel> logger, IUserRepository repository)
    {
        _log = logger;
        _repo = repository;
        _log.LogInformation("Injected the repo");
        Users = _repo.GetAll();
    }
}