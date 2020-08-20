namespace ProjectManager.DAL.Entities
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}