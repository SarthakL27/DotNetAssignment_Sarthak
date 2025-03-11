using NeoPolicy.Interfaces;
using NeoPolicy.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Repositories
{
    class LoginandRegister : IloginandRegister
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public bool Loggin(int id, string password)
        {
            using (sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(CustomerID) FROM Users WHERE CustomerID = @Id AND CustPassword = @Password";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int isValidUser = (int)cmd.ExecuteScalar();
                return (isValidUser > 0);
            }
        }

        public void Register(string name, string password)
        {
           using(sqlConnection =new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Users VALUES (@Name,@Password); SELECT CAST (SCOPE_IDENTITY() AS INT)";
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int id = (int)cmd.ExecuteScalar();
                Console.WriteLine("\n Your unique ID:" + id);
            }
        }
    }
}
