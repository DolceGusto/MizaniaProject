using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using MizaniaData.Data;

using MizaniaData.IGenericRepository;  

namespace MizaniaData.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
       
        public DbContextEntities _context;
        public DbSet<TEntity> _DbSet;
   
        public GenericRepository()
        {
          
            this._context = new DbContextEntities();
            this._DbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            
            IQueryable<TEntity> query = _DbSet;
            return query.ToList();
        }

        public TEntity GetByID(object id)
        {
            return _DbSet.Find(id);
        }
        public TEntity GetByID(object id, object id2)
        {
            return _DbSet.Find(id, id2);
        }

        public bool Insert(TEntity entity)
        {
            _DbSet.Add(entity);
           if (_context.SaveChanges() == 1)
                return true;
            else return false;
          //  return true;

        }

        public bool Delete(object id)
        {
            TEntity entityToDelete = _DbSet.Find(id);
            Delete(entityToDelete);
            if (_context.SaveChanges() == 1)
                return true;
            else return false;
        }

        public bool Delete(object id, object id2)
        {
            TEntity entityToDelete = _DbSet.Find(id,id2);
            Delete(entityToDelete);
            if (_context.SaveChanges() == 1)
                return true;
            else return false;
        }
        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _DbSet.Attach(entityToDelete);
            }
            _DbSet.Remove(entityToDelete);
        }

        public bool Update(TEntity entityToUpdate)
        {

            _DbSet.Attach(entityToUpdate); 
                         _context.Entry(entityToUpdate).State = EntityState.Modified;
                      //   return true; 
            if (_context.SaveChanges() == 1)
                return true;
            else return false; 
        }

       public void Detach(TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Detached;
        }


        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _DbSet.Where(predicate);
            return query.ToList();
        }

       public bool sauvegarder(int number)
        {
            if (_context.SaveChanges() == number)
                return true;
            else return false;
        }
    }
}