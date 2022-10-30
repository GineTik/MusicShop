using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected readonly DataContext _db;

        public Repository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            // найти как работает удаление по модели, мб можно изменить сравнение
            _db.Set<TEntity>().Remove(GetById(id));
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}
