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
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = "./SqlDBContext/MTHockeyTeam.db";
				_connection = new SqliteConnection(connectionStringBuilder.ConnectionString);

			}

			return _connection;
		}
	}
}

