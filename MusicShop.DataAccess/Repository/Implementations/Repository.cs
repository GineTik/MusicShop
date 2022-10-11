using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : IBaseEntity
        where TKey : IEquatable<TKey>
    {
        private readonly DataContext _db;

        public Repository(DataContext dataContext)
        {
            this._db = dataContext;
        }

        public void Add(TEntity entity)
        {
            this._db.Set<TEntity>().Add(entity);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._db.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return this._db.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            // найти как работает удаление по модели, мб можно изменить сравнение
            this._db.Set<TEntity>().Remove(GetById(id));
        }

        public void Update(TEntity entity)
        {
            this._db.Set<TEntity>().Update(entity);
        }
    }
}
