using System;
using SQLite;

namespace MyMoney.Core.Data
{
	public abstract class BaseEntity<TEntity>
		where TEntity : new()
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }

		public static BaseManager<TEntity> Manager
		{
			get { return new BaseManager<TEntity> (); }
		}
	}
}

