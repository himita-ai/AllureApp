//using AllureApp.Core.DB_Context;
//using AllureApp.Repository.Interface;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AllureApp.Repository.Implementation
//{
//    public class Repository<TEntity> :  IRepository<TEntity> where TEntity : class
//    {
//        protected readonly DbContext _dbContext;
//        public Repository(DbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public void Add(TEntity entity) =>

//            _dbContext.Set<TEntity>().Add(entity);


//        public void Delete(object id)
//        {
//            TEntity entity = _dbContext.Set<TEntity>().Find(id);
//            if (entity != null)  _dbContext.Set<TEntity>().Remove(entity);

//        }

//        public TEntity FindById(object id)=>_dbContext.Set<TEntity>().Find(id);


//        public IEnumerable<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();


//        public int SaveChanges() =>  _dbContext.SaveChanges();


//        public void Update(TEntity entity)=> _dbContext.Set<TEntity>().Update(entity);
//    }
//}
using AllureApp.Core.DBContext;
using AllureApp.Repository.Interface;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AllureApp.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AllureAppContext _dbContext;

        public Repository(AllureAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public TEntity FindById(object id) => _dbContext.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public int SaveChanges() => _dbContext.SaveChanges();
    }
}
