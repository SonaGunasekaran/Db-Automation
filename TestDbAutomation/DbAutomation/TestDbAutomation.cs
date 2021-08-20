using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestDbAutomation.DbAutomation
{
    [TestClass]
    public class TestDbAutomation
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Spotify";
        //creating sql connection 
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        UserDetails userData;
        [TestInitialize]
        public void Setup()
        {
            userData = new UserDetails();
        }
        //[TestMethod]
        public void TestMethod1()
        {
            using (this.sqlConnection)
            {
                this.sqlConnection.Open();
                //retrieve the query
                //SqlCommand insertCommand = new SqlCommand("Insert into Spotify_Table (FirstName,LastName,Age,Country,PhoneNumber,Email)values('" + userData.FirstName + "','" + userData.LastName + "'," + Convert.ToInt32(userData.Age)+ "'," + userData.Country+ "'," + Convert.ToDouble(userData.PhoneNumber) +  "','" + userData.Email +  "')";
                SqlCommand insertCommand = new SqlCommand("Insert into Spotify_Table (FirstName,LastName,Age,Country,PhoneNumber,Email)values(@FirstName,@LastName,@Age,@Country,@PhoneNumber,@Email");
                //insertCommand.Parameters.Add(new SqlParameter("Id", 6));
                insertCommand.Parameters.Add(new SqlParameter("@FirstName{0}", userData.FirstName));
                insertCommand.Parameters.Add(new SqlParameter("@LastName{0}", userData.LastName));
                insertCommand.Parameters.Add(new SqlParameter("@Age{0}", userData.Age));
                insertCommand.Parameters.Add(new SqlParameter("@Country{0}", userData.Country));
                insertCommand.Parameters.Add(new SqlParameter("@PhoneNumber{0}", userData.PhoneNumber));
                insertCommand.Parameters.Add(new SqlParameter("@Email{0}", userData.Email));

                int result = insertCommand.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Inserted successfully");
                }
            }
        }
        public UserDetails Test()
        {
            userData.FirstName = "Keerthi";
            userData.LastName = "Suresh";
            userData.Age = 19;
            userData.Country = "US";
            userData.PhoneNumber = 987234666;
            userData.Email = "keer@gmail.com";
            return userData;
        }
        public int RetrieveData()
        {
            //Count the number of data in table
            int count = 0;
            using (sqlConnection)
            {
                //Retrieve query
                string query = @"select * from Spotify_Table";
                SqlCommand command = new SqlCommand(query, this.sqlConnection);
                //open sql connection
                sqlConnection.Open();
                //sql reader to read data
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        count++;
                    }
                }
                //close reader
                sqlDataReader.Close();
            }
            this.sqlConnection.Close();
            return count;
        }
        [TestMethod]
        public void TestMethodForRetriveDataUsingQuery()
        {
            int expected = 6;
            var actual = RetrieveData();
            Assert.AreEqual(expected, actual);
        }
        public int RetrieveDataBasedOnStateAndCity()
        {
            int count = 0;
           
                using (sqlConnection)
                {
                    //Query Execution
                    string query = @"Select FirstName from Spotify_table where Country='India'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    //SqlDataReader
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            userData.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                            Console.WriteLine("FirstName :{0}", userData.FirstName);
                        }
                    }
                }
                //closes the connection
                sqlConnection.Close();
                return count;
        }
        [TestMethod]
        public void TestMethodForRetrieveDataBasedOnCityAndState()
        {
            int expected = 4;
            var actual=RetrieveDataBasedOnStateAndCity();
            Assert.AreEqual(expected, actual);
        }

    }
}
