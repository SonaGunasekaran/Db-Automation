using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestDbAutomation.DbAutomation
{
    [TestClass]
    public class TestDbAutomation
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_Automation";
        //creating sql connection 
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        [TestMethod]
        public void TestMethod1()
        {
            using (this.sqlConnection)
            {
                this.sqlConnection.Open();
                //retrieve the query
                SqlCommand insertCommand = new SqlCommand("Insert into DB_table (Col1,col2,col3,col4,col5)values(@0,@1,@2,@3,@4)",this.sqlConnection);
                insertCommand.Parameters.Add(new SqlParameter("0", 1));
                insertCommand.Parameters.Add(new SqlParameter("1", "Sona"));
                insertCommand.Parameters.Add(new SqlParameter("2", 20));
                insertCommand.Parameters.Add(new SqlParameter("3", DateTime.Now));
                insertCommand.Parameters.Add(new SqlParameter("4", "son@gmail.com"));
                int rows = insertCommand.ExecuteNonQuery();
                Assert.AreEqual(1, rows);
            }

        }
    }
}
