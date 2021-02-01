using Microsoft.EntityFrameworkCore;
using ServicePix.In.Model;
using ServicePix.In.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ServicePix.Repositorio
{
    public class Base<T> : IBase<T> where T : class
    {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            var context = new spContext();

            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();

            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list = new List<T>();
            var context = new spContext();
            IQueryable<T> dbQuery = context.Set<T>().AsQueryable();

            var query = context.Set<T>().AsQueryable();

            //Apply eager loading

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();


            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            var context = new spContext();
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause

            return item;
        }

        public virtual object Add(params T[] items)
        {
            var context = new spContext();
            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Added;
            }
            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public virtual void Update(params T[] items)
        {
            var context = new spContext();
            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();

        }
        public virtual void Remove(params T[] items)
        {
            var context = new spContext();
            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
            context.SaveChanges();

        }
    }
}
