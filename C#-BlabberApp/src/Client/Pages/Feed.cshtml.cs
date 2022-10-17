using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;
public class FeedModel : PageModel
{
    [BindProperty]
    public string? Content { get; set; }
    [BindProperty]
    public string? Username { get; set; }
    public IEnumerable<Blab> Blabs;
    private readonly ILogger<FeedModel> _log;
    private readonly IBlabRepository _repo;
    public FeedModel(ILogger<FeedModel> logger, IBlabRepository repository)
    {
        _log = logger;
        _repo = repository;
        _log.LogInformation("Injected the repo");
        Blabs = _repo.GetAll();
    }

    public void OnGet() {}

    public void OnPost()
    {
        Blab blab = new(Content, Username);
        _repo.Add(blab);

        _log.LogInformation("Add blab into repo");
    }
}