using System;
using SQLite;

namespace MyMoney.Core.Data
{
	[Table("Accounts")]
	public class Account : BaseEntity<Account>
	{
		[MaxLength(30)]
		public string Name { get; set; }

		public decimal Balance { get; set; }
	}
}

