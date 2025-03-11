using NeoPolicy.Interfaces;
using NeoPolicy.Models;
using NeoPolicy.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Repositories
{
    class PolicyWork : Ipolicy
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public bool AddPolicy(int cutomerId, string name, int PolicyType, int PolicyPeriod)
        {
            using(sqlConnection =new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd=new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText="INSERT INTO Policies VALUES(@CustomerId,@PolicyHolderName,@PolicyType,@StartDate,@EndDate)";
                cmd.Parameters.AddWithValue("@CustomerId",cutomerId);
                cmd.Parameters.AddWithValue("@PolicyHolderName",name);
                cmd.Parameters.AddWithValue("@PolicyType", PolicyType);
                DateTime startDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-mm-dd"));
                cmd.Parameters.AddWithValue("@EndDate", startDate.AddYears(PolicyPeriod).ToString("yyyy-mm-dd"));
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int effectedRow = cmd.ExecuteNonQuery();
                return (effectedRow > 0);


            }
        }

        public bool DeletePolicy(int customerId, int policyId)
        {
            using(sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText="DELETE FROM Policies WHERE PolicyID=@PolicyId AND CustomerID=@Id";
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Parameters.AddWithValue("@Id", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int effectRow = cmd.ExecuteNonQuery();
                return (effectRow > 0);
            }
        }

        public List<Policy> SearchPolicyById(int customerId, int policyId)
        {
           using(sqlConnection =new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE CustomerID=@CustomerId AND PolicyId=@Id";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Id", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyID = (int)reader["PolicyID"],
                        CustomerID = (int)reader["CustomerID"],
                        PolicyHolderName = reader["PolicyHolderName"].ToString(),
                        PolicyType = (int)reader["PolicyType"],
                        StartDate=Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }
        }

        public List<Policy> ShowActivePolicy(int customerId)
        {
            using (sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE CustomerID = @CustomerId AND (@Now BETWEEN StartDate AND EndDate)";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyID = (int)reader["PolicyID"],
                        CustomerID = (int)reader["CustomerID"],
                        PolicyHolderName = reader["PolicyHolderName"].ToString(),
                        PolicyType = (int)reader["PolicyType"],
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }

        }

        public bool UpdatePolicyById(int customerId, int policyId)
        {
            int isValid = 0;
            using (sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(PolicyId) FROM Policies WHERE UserId = @CustomerId AND PolicyId = @Id";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Id", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                isValid = (int)cmd.ExecuteScalar();
            }
            if (isValid > 0)
            {
                Policy policy = new Policy();
                using (sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
                {
                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT TOP 1 * FROM Policies WHERE UserId = @CustomerId AND PolicyId = @Id";
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Id",policyId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policy.PolicyHolderName = reader.GetString("HolderName");
                        policy.PolicyType = reader.GetInt32("Type");
                        policy.StartDate = reader.GetDateTime("StartDate");
                        policy.EndDate = reader.GetDateTime("EndDate");
                    }
                }
                Console.Write("Holder name : ");
                string holderName = Console.ReadLine();
                if (!string.IsNullOrEmpty(holderName))
                {
                    policy.PolicyHolderName = holderName;
                }
                Console.Write("Type : ");
                bool isType = int.TryParse(Console.ReadLine(), out int type);
                if (isType)
                {
                    policy.PolicyType = type;
                }
                Console.Write("Period : ");
                bool isPeriod = int.TryParse(Console.ReadLine(), out int period);
                if (isPeriod)
                {
                    policy.EndDate = policy.StartDate.AddYears(period);
                }
                using (sqlConnection = new SqlConnection(DatabaseConnUtil.GetConnectionString()))
                {
                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Policies SET HolderName = @HolderName,Type = @PolicyType,EndDate = @EndDate WHERE UserId = @CustomerId AND PolicyId = @Id";
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Id", policyId);
                    cmd.Parameters.AddWithValue("@HolderName", policy.PolicyHolderName);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                    cmd.Parameters.AddWithValue("@EndDate", policy.EndDate.ToString("yyyy-MM-dd"));
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int effectedRow = cmd.ExecuteNonQuery();
                    return (effectedRow > 0);
                }
            }
            return false;
        }

        public List<Policy> ViewAllPolicy(int customerId)
        {
           using(sqlConnection =new SqlConnection(DatabaseConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE CustomerID=@CustomerID";
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyID = (int)reader["PolicyId"],
                        CustomerID = (int)reader["CustomerID"],
                        PolicyHolderName = reader["PolicyHolderName"].ToString(),
                        PolicyType = (int)reader["PolicyType"],
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }
        }
    }
}
