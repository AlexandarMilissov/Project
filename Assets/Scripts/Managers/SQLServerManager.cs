using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class SQLServerManager : MonoBehaviour
{
    static string connectionString =
      @"server=PC_ALEX\SQLEXPRESS;database=Project;User Id = Project; Password=1234;";

    static string queryString = "SELECT * from Table_1";

    static SqlConnection sqlConnection = new SqlConnection(connectionString);
    SqlCommand sqlCommand = new SqlCommand(queryString,sqlConnection);

    public void Start()
    {
        sqlConnection.Open();
        using (SqlDataReader reader = sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                Debug.Log (String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }
        }
    }
}
