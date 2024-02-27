using Domain;
using Domain.Entities;
using Domain.Services;
using LiteDB;

namespace Infrastructure.Database
{
    /// <summary>
    /// Handles database operations using LiteDB (NoSQL)
    /// </summary>
    public class DDDItemRepository : IRepository<DDDItem>
    {
        private LiteDatabase _database;
        private ILiteCollection<DDDItem> _collection;

        public DDDItemRepository(LiteDatabase database)
        {
            _database = database;
            _collection = _database.GetCollection<DDDItem>("DDDs");
        }
        public int Insert(DDDItem entity) => _collection.Insert(entity);

        public bool Delete(int id) => _collection.Delete(id);

        public bool DeleteAll() => _collection.DeleteAll() > 0;

        public IEnumerable<DDDItem> GetAll()
        {
            var items = _collection.FindAll();
            return items ?? Enumerable.Empty<DDDItem>();
        }

        public DDDItem GetById(int id) => _collection.FindById(id);

        public bool Update(DDDItem entity) => _collection.Update(entity);

        public bool Upsert(DDDItem entity) => _collection.Upsert(entity);

        /// <summary>
        /// No need to implement since LiteDB does not have a dispose method.
        /// </summary>
        public void Dispose() { }
    }

}
