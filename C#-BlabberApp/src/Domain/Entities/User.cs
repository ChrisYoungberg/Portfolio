using Domain.Common.Interfaces;
using System.Net.Mail;

namespace Domain.Entities;

public class User : IEntity
{
    public DateTime DttmCreated {get; set;}
    public DateTime DttmLastLogin { get; set;}
    public MailAddress? Email { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullNameFirstLast { get { return FirstName + " " + LastName; } }
    public string? FullNameLastFirst { get { return LastName + ", " + FirstName; } }
    public Guid Id { get; set; }

    public User()
    {
        DttmCreated = DttmLastLogin = DateTime.Now;
        Id = Guid.NewGuid();
    }

    public User(string? username, string email)
    {
        DttmCreated = DttmLastLogin = DateTime.Now;
        Username = username;
        Email = new MailAddress(email);
        Id = Guid.NewGuid();
    }

    public User(string username, string email, string firstName, string lastName)
    {
        DttmCreated = DttmLastLogin = DateTime.Now;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = new MailAddress(email);
        Id = Guid.NewGuid();
    }

    public User(string username, string email, string firstName, string lastName, DateTime created, DateTime login)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = new MailAddress(email);
        DttmCreated = created;
        DttmLastLogin = login;
    }

    public bool AreEqual(IEntity u)
    {
        return false;
    }

    public void Validate()
    {
        // TODO is there an email
        // TODO is email format valid
        // TODO username exists
        throw new NotImplementedException();
    }
}