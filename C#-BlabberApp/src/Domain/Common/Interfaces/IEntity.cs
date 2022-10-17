namespace Domain.Common.Interfaces;

public interface IEntity
{
    public bool AreEqual(IEntity entity);
    public void Validate();
}