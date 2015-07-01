using System;
using SQLite;

namespace MyMoney.Core.Data
{
	[Table("Transactions")]
	public class Transaction : BaseEntity<Transaction>
	{
		// todo: how to create the foreign key?
		public int AccountId { get; set; }

		public decimal Ammount { get; set; }
	}
}

