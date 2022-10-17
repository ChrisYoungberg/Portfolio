using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using WebApi.Dto;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlabsController : ControllerBase
{
    private readonly ILogger<BlabsController> _logger;
    private readonly IBlabRepository _repo;
    private readonly IUserRepository _userRepo;

    public BlabsController(ILogger<BlabsController> logger, IBlabRepository repo, IUserRepository userRepo)
    {
        _logger = logger;
        _repo = repo;
        _userRepo = userRepo;
    }

    [HttpGet(Name = "Blabs")]
    public IEnumerable<Blab> GetAll()
    {
        _logger.LogInformation("Retrieving all the blabs");
        return _repo.GetAll();
    }

    [HttpGet]
    [Route("OrderByDate")]
    public IEnumerable<Blab> GetAllByDate()
    {
        _logger.LogInformation("Retrieving all the blabs");
        return _repo.GetAll().OrderBy(b => b.DttmCreated);
    }

    [HttpGet]
    [Route("OrderByUser")]
    public IEnumerable<Blab> GetAllByUser()
    {
        _logger.LogInformation("Retrieving all the blabs");
        return _repo.GetAll().OrderBy(b => b.Username);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("Retrieving blab " + id);
        var b = _repo.GetById(id);
        if (b.Username is "")
            return NotFound();
        return Ok(b);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BlabDto? bDto)
    {
        if (bDto is null)
        {
            _logger.LogError("Blab object is null");
            return BadRequest("Blab object is null");
        }

        try
        {
            var user = _userRepo.GetByUsername(bDto.Username);
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException(e.Message);
        }

        try
        {
            Blab b = new(bDto.Content, bDto.Username);

            _repo.Add(b);

            return CreatedAtRoute("Blabs", new {id = b.Id}, b);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}