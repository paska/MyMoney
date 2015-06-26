using System;
using SQLite;

namespace MyMoney.Core.Data
{
	[Table("Accounts")]
	public class Account
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }

		[MaxLength(30)]
		public string Name { get; set; }
	}
}

