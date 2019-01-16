using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// buradan nasıl kullanılabilgiğini gör : https://stackoverflow.com/questions/51652326/ef-core-the-instance-of-entity-type-cannot-be-tracked-and-context-dependency-in
namespace SehirRehberi.API.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public MyAppDatabaseContext _context;
		public DbSet<T> dbset;

		public GenericRepository(MyAppDatabaseContext context)
		{
			_context = context;
			dbset = context.Set<T>();
		}

		public IQueryable<T> GetAll()
		{
			return dbset;
		}

		public T GetByID(params object[] keyValues)
		{
			return dbset.Find(keyValues);
		}

		public void Edit(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void Insert(T entity)
		{
			dbset.Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Entry(entity).State = EntityState.Deleted;
		}

		public T GetByFunc(Func<T, bool> func)
		{
			return dbset.AsQueryable().Where(x => func(x)).FirstOrDefault();
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

	}
}
