using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MizaniaData.Data; 

namespace MizaniaData.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(); 
        TEntity GetByID(object id);
        TEntity GetByID(object id, object id2);
        bool Insert(TEntity entity);
        bool Delete(object id);
        bool Delete(object id, object id2);
        void Delete(TEntity entityToDelete);
        bool Update(TEntity entityToUpdate);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Detach(TEntity entityToUpdate);
        bool sauvegarder(int number); 
        
    }
}
