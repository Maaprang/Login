
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Login.database
{
	public class Database
	{
      	 private string ConString = "server=localhost;port=3306;database=webproject;user=root;password=login165930";
        public MySqlConnection myConnection;

        public Database()
        {
            myConnection = new MySqlConnection(ConString);
            myConnection.Open();
        }

        public DataTable GetData(string _sqlCommand)
        {
            MySqlCommand command = new MySqlCommand(_sqlCommand, myConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void ExecuteQuery(string _sqlCommand)
        {
            MySqlCommand command = new MySqlCommand("", myConnection);
            command.CommandText = _sqlCommand;
            command.CommandType = CommandType.Text;
            command.Connection = myConnection;
            command.ExecuteNonQuery();
        }
	}
}