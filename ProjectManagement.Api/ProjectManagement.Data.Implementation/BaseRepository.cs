using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private PMContext _context;
        public BaseRepository(PMContext context )
        {
            _context = context;
        }
        public T Add(T entity)
        {
           var entityCreated= _context.BaseEntitys.Add(entity);
            _context.SaveChanges();

            if (entityCreated != null)
                return (T)entityCreated.Entity;

            return null;
        }


        public bool Delete(long id)
        {
            T entity=Get(id);
            if (entity == null)
                return false;
            _context.BaseEntitys.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<T> Get()
        {
            var entityList = _context.Set<T>().ToList();
            return entityList;
        }

        public T Get(long id)
        {
            var result= (T)_context.BaseEntitys.Where(x=>x.Id==id).FirstOrDefault();
            return result;
        }

        public T Update(T entity)
        {
            
            T originalEntity = Get(entity.Id);

            if (originalEntity == null)
            {
                return null;
            }

            _context.Entry(originalEntity).CurrentValues.SetValues(entity);
            //_context.BaseEntitys.Update(originalEntity);
            _context.SaveChanges();
            return entity;
        }
    }
}
