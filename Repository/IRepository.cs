using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        int Count();
        int Count(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        T GetSingleIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(int count);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        //IQueryable<T> GetHeirarchyData(string sql, int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);

        //Tuple<int, IQueryable<T>> AllIncludingWithQuery(int skip, int take, string sortColumn, string sortColumnDirection, Expression<Func<T, bool>> search, params Expression<Func<T, object>>[] includeProperties);
    }
}
