using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskForBits.Models;
namespace TaskForBits.Services
{
    public class DBService
    {


        public void SetUserIntoDB(User user, string strConn)
        {
            string sqlQuery = $"EXEC AddUser @Name, @DateOfBirth, @Married, @Phone, @Salary";
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = user.Name;
                command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date).Value = user.DateOfBirth;
                command.Parameters.Add("@Married", System.Data.SqlDbType.TinyInt).Value = user.Married;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar).Value = user.Phone;
                command.Parameters.Add("@Salary", System.Data.SqlDbType.Decimal).Value = user.Salary;
                command.ExecuteNonQuery();
            }

        }
        public List<User> GetUsers(string strConn)
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        users.Add(new User(Convert.ToInt32(oReader["UserID"]), oReader["Name"].ToString(), Convert.ToDateTime(oReader["DateOfBirth"]),
                            Convert.ToBoolean(oReader["Married"]), oReader["Phone"].ToString(), Convert.ToDecimal(oReader["Salary"])));
                    }

                    connection.Close();
                }
            }
            return users;
        }
        public void DeleteUser(int UserID)
        {
            string connectionString = @"Data Source=DESKTOP-R7LP984;Initial Catalog=BitsDB;Integrated Security=True";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                string sql =
                    "DELETE Users WHERE UserID = " + UserID;
                SqlCommand oCmd = new SqlCommand(sql, myConnection);
                oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
    }
}