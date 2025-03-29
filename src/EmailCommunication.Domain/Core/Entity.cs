namespace EmailCommunication.Domain.Core;

public class Entity<TEntity> where TEntity : class
{
    protected int Id { get; set; }    
}
