using System;
using Microsoft.Data.Sqlite;

namespace MontrealHockeyTeamAPI.SqlDBContext
{
	public static class DBConnector
	{
		private static SqliteConnection _connection;
		public static SqliteConnection Connection()
		{
			if(_connection == null)
            {
				_connection = new SqliteConnection(Path.Combine("Data Source=SqlDBContext", "MTHockeyTeam.db"));

			}

			return _connection;
		}
	}
}

