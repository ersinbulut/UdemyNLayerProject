using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);//id ye göre nesne getir

        Task<IEnumerable<TEntity>> GetAllAsync();//tüm nesneleri getir
        //find(x=>x.id=23)
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);//herhangi bir parametreye göre ilgili nesneleri bul
        //category.SingleOrDefault(x=>x.name="kalem")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

    }
}
