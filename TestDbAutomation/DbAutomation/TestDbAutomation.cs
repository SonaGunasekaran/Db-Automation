/*
 * Project:Connecting to Spotify Database
 * Author:Sona G
 * Date :19/08/2021
 */
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
        [TestMethod]
        public void RetrieveDataBasedOnStateAndCity()
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText =
                          "Select FirstName from Spotify_Table where Country='India'" +
                          "Select FirstName from Spotify_Table where Age= 23" +
                          "select FirstName from Spotify_Table Where Country='India' order by(FirstName)" +
                          "Select LastName from Spotify_Table where Age = 24";
                    SqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    do
                    {
                        while (mySqlDataReader.Read())
                        {
                            Console.WriteLine("mySqlDataReader[0] = " + mySqlDataReader[0]);
                        }
                        Console.WriteLine(""); // visually split the results
                    } while (mySqlDataReader.NextResult());

                    mySqlDataReader.Close();
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
        }
        [TestMethod]
        public void UpdateData()
        {
            try
            {
                using (sqlConnection)
                {
                    //open sql connection
                    sqlConnection.Open();
                    //sql reader to read data
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText =
                        "update Spotify_Table set Country='Russia' where FirstName='Chandler'" +
                        "update Spotify_Table set Age=34 where FirstName = 'Monica'" +
                        "delete from Spotify_Table  where FirstName ='Katherine'" +
                        "delete from Spotify_Table  where FirstName ='Maanvi'";
                    SqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    do
                    {
                        while (mySqlDataReader.Read())
                        {

                            Console.WriteLine("mySqlDataReader[0] = " + mySqlDataReader[0]);
                        }
                        Console.WriteLine(""); // visually split the results
                    } while (mySqlDataReader.NextResult());

                    mySqlDataReader.Close();
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
        }
    }
}
