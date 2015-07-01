using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.IO;

namespace MyMoney.Core.Data
{
	public class BaseManager<TEntity> : IDisposable
		where TEntity : new()
	{
		protected SQLiteConnection database;

		public BaseManager ()
		{
			string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
			this.database = new SQLiteConnection (dbPath);

			if (!this.database.TableExists<TEntity>())
				this.database.CreateTable<TEntity>();
		}

		public void Dispose()
		{
			this.database.Close();
		}

		public List<TEntity> GetAll()
		{
			return this.database.Table<TEntity>().ToList ();
		}

		public TEntity Get(int id)
		{
			return this.database.Get<TEntity> (id);
		}

		public void Insert(TEntity entity)
		{
			this.database.Insert(entity);
		}

		public void Update(TEntity entity)
		{
			this.database.Update(entity);
		}

		public void Delete(TEntity entity)
		{
			this.database.Delete(entity);
		}
	}
}

