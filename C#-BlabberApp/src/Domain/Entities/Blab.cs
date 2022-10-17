using Domain.Common.Interfaces;

namespace Domain.Entities;

public class Blab : IEntity
{
    public string Content { get; set; }
    public string Username { get; set; }
    public DateTime DttmCreated { get; set; }
    public DateTime DttmModified { get; set; }
    public Guid Id { get; set; }

    public Blab()
    {
        Content = "test";
        Username = "test";
        DttmCreated = DttmModified = DateTime.Now;
        Id = Guid.NewGuid();
    }

    public Blab(string Msg, string Usr)
    {
        Content = Msg;
        Username = Usr;
        DttmCreated = DttmModified = DateTime.Now;
        Id = Guid.NewGuid();
    }

    public Blab(string Msg, string Usr, DateTime created, DateTime modified)
    {
        Content = Msg;
        Username = Usr;
        DttmCreated = created;
        DttmModified = modified;
    }

    public bool AreEqual(IEntity b)
    {
        return false;
    }

    public void Validate()
    {
        // TODO content exists
        // TODO a user exists
        // throw new InvalidDataException("Blab");
        throw new NotImplementedException();
    }
}