using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        
        DbSet<T> set;

        public GenericRepository()
        {
            set=context.Set<T>();
        }

        public void Delete(T item)
        {
            set.Remove(item);
            context.SaveChanges();
        }

        public void Insert(T item)
        {
            set.Add(item);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return set.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return set.Where(filter).ToList();
        }

        public void Update(T item)
        {
            context.SaveChanges();
        }
    }
}
