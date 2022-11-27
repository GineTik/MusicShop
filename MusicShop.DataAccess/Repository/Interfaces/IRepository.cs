using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> : IDisposable 
        where TEntity : IBaseEntity
        where TKey: IEquatable<TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        bool Remove(TKey id);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void SaveChanges();
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : IBaseEntity
    {   

    }
}
