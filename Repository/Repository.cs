using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EmployeeManagementDbContext _context;

        public Repository(EmployeeManagementDbContext context)
        {
            _context = context;
        }


        //public IQueryable<T> GetHeirarchyData(string sql, int id)
        //{
        //    try
        //    {
        //        return _context.Set<T>().AsNoTracking().FromSql(sql, id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public virtual void Add(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual async Task AddAsync(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var query = _context.Set<T>().AsNoTracking();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual int Count()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public virtual async Task<int> CountAsync()
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().Where(predicate).CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.AsNoTracking().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return await query.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {

                EntityEntry dbEntityEntry = _context.Entry(entity);
               //dbEntityEntry.State = EntityState.Modified;
                _context.Set<T>().Attach(entity);
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                dbEntityEntry.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entites = _context.Set<T>().Where(predicate);
                foreach (var entity in entites)
                {
                    _context.Entry<T>(entity).State = EntityState.Deleted;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.AsNoTracking().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IQueryable<T> GetAll(int count)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().AsQueryable().Take(count);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingleIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.AsNoTracking().Where(predicate).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> GetSingleIncludingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return await query.AsNoTracking().Where(predicate).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public virtual Tuple<int, IQueryable<T>> AllIncludingWithQuery(int skip, int take, string sortColumn, string sortColumnDirection, Expression<Func<T, bool>> search, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    try
        //    {
        //        var query = _context.Set<T>().AsNoTracking().OrderBy(sortColumn).Where(search).Skip(skip).Take(take);
        //        int totalresult = _context.Set<T>().AsNoTracking().Where(search).Count();
        //        foreach (var includeProperty in includeProperties)
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //        return new Tuple<int, IQueryable<T>>(totalresult, query.AsQueryable());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
