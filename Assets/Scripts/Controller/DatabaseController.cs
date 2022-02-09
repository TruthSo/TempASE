using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DatabaseController : MonoBehaviour
{

    public static IDbConnection dbconn;

    public DatabaseController()
    {
        if (dbconn == null)
        {
            ConnectDb();
        }
        Debug.Log("test DatabaseController");
    }

    //https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

    public void ConnectDb()
    {
        Debug.Log("test ConnectDb");
        var database_name = "";
        var conn = "URI=file:" + Application.dataPath + "/" + database_name;

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
    }

    ~DatabaseController()
    {
        dbconn.Close();
        dbconn = null;
    }



}
