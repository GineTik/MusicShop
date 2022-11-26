using Microsoft.EntityFrameworkCore;
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


        public TEntity Add(TEntity entity)
        {
            var e = _db.Set<TEntity>().Add(entity).Entity;
            SaveChanges();
            return e;
            
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public bool Remove(int id)
        {
            // найти как работает удаление по модели, мб можно изменить сравнение
            var e = _db.Set<TEntity>().Remove(GetById(id)).State;
            SaveChanges();

            if (e == EntityState.Deleted)
                return true;
            return false;
        }

        public TEntity Update(TEntity entity)
        {
            var e = _db.Set<TEntity>().Update(entity).Entity;
            SaveChanges();
            return e;
        }

        
    }
}
