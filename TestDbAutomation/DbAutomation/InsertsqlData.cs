/*
 * Project:Connecting to Spotify Database
 * Author:Sona G
 * Date :21/08/2021
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestDbAutomation.DbAutomation
{
    [TestClass]
    public class InsertsqlData
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Spotify";
        //creating sql connection 
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public int TestMethod1(string firstName, string lastName, int age, string country, double phoneNumber, string email)
        {
            int count = 0;
            using (this.sqlConnection)
            {
                try
                {
                    this.sqlConnection.Open();
                    SqlCommand insertCommand = new SqlCommand("dbo.InsertTable", this.sqlConnection);

                    insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertCommand.Parameters.AddWithValue("@Age", age);
                    insertCommand.Parameters.AddWithValue("@Country", country);
                    insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    insertCommand.Parameters.AddWithValue("@Email", email);

                    int result = insertCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Inserted successfully");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    this.sqlConnection.Close();
                }
                return count;
            }

        }

        [DataRow("Maanvi", "Kumar", 12, "US", 9876512348, "manvi@gmail.com")]
        [DataRow("Katherine", "Nikcol", 42, "Russia", 98812348, "kathr@gmail.com")]
        [DataTestMethod]
        public void Test(string firstName, string lastName, int age, string country, double phoneNumber, string email)
        {
            int expected = 1;
            UserDetails userData = new UserDetails();
            var actual = TestMethod1(firstName, lastName, age, country, phoneNumber, email);
            Assert.AreEqual(expected, actual);

        }
    }
}
