using System.Net.Mail;

using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using WebApi.Dto;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _repo;

    public UserController(ILogger<UserController> logger, IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet(Name = "User")]
    public IEnumerable<User> GetAll()
    {
        _logger.LogInformation("Retrieving all the users");
        return _repo.GetAll();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("Retrieving user " + id);
        var u = _repo.GetById(id);
        if (u.Username is "")
            return NotFound();
        return Ok(u);
    }

    [HttpGet]
    [Route("Username/{username}")]
    public IActionResult GetByUsername([FromRoute] string username)
    {
        _logger.LogInformation("Retrieving user " + username);
        var u = _repo.GetByUsername(username);
        return Ok(u);
    }

    [HttpGet]
    [Route("Email/{email}")]
    public IActionResult GetByEmail([FromRoute] string email)
    {
        _logger.LogInformation("Retrieving user " + email);
        var u = _repo.GetByEmail(email);
        if (u.Username is "")
            return NotFound();
        return Ok(u);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto? uDto)
    {
        try
        {
            if (uDto is null)
            {
                _logger.LogError("User object is null");
                return BadRequest("User object is null");
            }

            User u = new(uDto.Username, uDto.Email);
            u.FirstName = uDto.FirstName;
            u.LastName = uDto.LastName;

            _repo.Add(u);

            return CreatedAtRoute("User", new { id = u.Id }, u);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] UserDto? uDto)
    {
        try
        {
            if (uDto is null)
            {
                _logger.LogError("User object is null");
                return BadRequest("User object is null");
            }

            User u = _repo.GetByUsername(uDto.Username);

            u.Username = uDto.Username;
            u.Email = new MailAddress(uDto.Email);
            u.FirstName = uDto.FirstName;
            u.LastName = uDto.LastName;

            _repo.Update(u);

            return CreatedAtRoute("User", new { id = u.Id }, u);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            var u = _repo.GetById(id);
            _repo.Remove(u);
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

}