using System.Data;

namespace Steve.SqlLite
{
	public class MySqlLiteParameter
	{
		public MySqlLiteParameter(string name, DbType dbType, object value)
		{
			Name = name;
			DbType = dbType;
			Value = value;
		}

		public string Name { get; set; }
		public object Value { get; set; }
		public DbType DbType { get; set; }
	}
}