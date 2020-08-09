namespace ProjectManager.DAL.Entities
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}