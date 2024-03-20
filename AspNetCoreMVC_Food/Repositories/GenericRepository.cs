using AspNetCoreMVC_Food.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNetCoreMVC_Food.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        Context db = new Context();
        public List<TEntity> TList()
        {
            return db.Set<TEntity>().ToList();
        }


        public void TAdd(TEntity p)
        {
            db.Set<TEntity>().Add(p);
            db.SaveChanges();
        }


        public void TRemove(TEntity p)
        {
            db.Set<TEntity>().Remove(p);
            db.SaveChanges();

        }


        public void TUpdate(TEntity p)
        {
            db.Set<TEntity>().Update(p);
            db.SaveChanges();
        }


        public TEntity TGet(int id)
        {
            return db.Set<TEntity>().Find(id);

        }


        public List<TEntity> TList(string p)
        {
            return db.Set<TEntity>().Include(p).ToList();
        }


        public List<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            return db.Set<TEntity>().Where(filter).ToList();
        }
    }
}
