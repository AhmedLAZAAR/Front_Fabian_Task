namespace Domain.Services
{
    /// <summary>
    /// CRUD interface, where the persistence (DB) operations are
    /// abstracted to the Interface layer.
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : Domain.Entities.DDDItem
    {
        int Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Upsert(TEntity entity);
        bool Delete(int id);
        bool DeleteAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
