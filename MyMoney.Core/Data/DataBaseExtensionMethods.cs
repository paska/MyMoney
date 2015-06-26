using System;
using SQLite;

namespace MyMoney.Core.Data
{
	public static class DataBaseExtensionMethods
	{
		public static bool TableExists<T> (this SQLiteConnection connection)
		{    
			const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
			var cmd = connection.CreateCommand (cmdText, typeof(T).Name);
			return cmd.ExecuteScalar<string> () != null;
		}
	}
}

