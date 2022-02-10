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
            Debug.Log("dbconn is null");
            ConnectDb();
        }
        Debug.Log("test DatabaseController");
    }

    //https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

    public void ConnectDb()
    {
        Debug.Log("test ConnectDb");
        var database_name = "LinkItDb.db";
        var conn = "URI=file:" + Application.dataPath + "/database/" + database_name;

        Debug.Log("conn: " + conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
    }

    ~DatabaseController()
    {
        dbconn.Close();
        dbconn = null;
        Debug.Log("calling destructor");
    }

    #region Patients
    public List<Patient> SelectAllPatients()
    {
        string query = Constants.SqliteCommand.SelectAll + Constants.PatientTable.TABLE_NAME;

        IDataReader data = ExecuteQuery(query);
        return PatientsToViewModel(data);
    }

    public Patient SelectPatientById(int id)
    {
        Debug.Log("SelectPatientById id:" + id);
        string query = Constants.SqliteCommand.SelectAll + Constants.PatientTable.TABLE_NAME + " where PatientId=" + id;

        IDataReader data = ExecuteQuery(query);
        return PatientsToViewModel(data)?.ToArray()[0];
    }

    public void AddPatient(Patient patient)
    {
        string query = Constants.SqliteCommand.InsertPatient;

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbcmd.Parameters.Add(CreateParameter(dbcmd, "@id", Constants.SqliteCommand.AUTO_INCREMENTAL));
        dbcmd.Parameters.Add(CreateParameter(dbcmd, "@name", patient.Name));
        ExecuteNonQuery(dbcmd);
    }

    //todo Update Patient
    //todo Delete Patient

    //todo Add Score
    //todo Update Score
    //todo Delete Score

    private IDbDataParameter CreateParameter(IDbCommand dbcmd, string columnName,string value)
    {
        IDbDataParameter parameter = dbcmd.CreateParameter();
        parameter.ParameterName = columnName;
        parameter.Value = value;
        return parameter;
    }

    #endregion

    #region Scores
    //
    #endregion


    private List<Patient> PatientsToViewModel(IDataReader data)
    {
        List<Patient> patients = new List<Patient>();
        while (data.Read())
        {
            int id = data.GetInt32(0);
            string name = data.GetString(1);

            Patient patient = new Patient(id.ToString(),name);
            patients.Add(patient);

            Debug.Log("Print id: " + id + "  name: " + name);
        }

        data.Close();

        Debug.Log("Total patients: " + patients.Count);
        return patients;
    }

    #region Common
    //Reference: http://csharp.net-informations.com/data-providers/csharp-executereader-executenonquery.htm

    //ExecuteQuery for queries that getting data from database.
    private IDataReader ExecuteQuery(string query)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        return dbcmd.ExecuteReader();
    }

    //ExecuteNonQuery for queries that does not return any data. Such as update, insert, delete
    private void ExecuteNonQuery(IDbCommand dbcmd)
    {
        bool querystatus = dbcmd.ExecuteNonQuery() != 0;

        //result '0' == sql operation failed
        if (querystatus)
        {
            Debug.Log("Print AddPatient successfully.");
        }
        else
        {
            Debug.Log("Print AddPatient unsuccessfully!");
        }
    }
    #endregion



    //parameterized sqlite 
    //https://stackoverflow.com/questions/2662999/system-data-sqlite-parameterized-queries-with-multiple-values

    //Best practices
    //https://stackoverflow.com/questions/8234971/adding-parameters-to-idbcommand
    //https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md
}
