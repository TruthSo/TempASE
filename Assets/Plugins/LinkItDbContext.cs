using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
public class LinkItDbContext : SqliteHelper
{
    public LinkItDbContext() : base()
    {
        // IDbCommand dbcmd = getDbCommand();
        // dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
        //     KEY_ID + " TEXT PRIMARY KEY, " +
        //     KEY_TYPE + " TEXT, " +
        //     KEY_LAT + " TEXT, " +
        //     KEY_LNG + " TEXT, " +
        //     KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
        // dbcmd.ExecuteNonQuery();
        Debug.Log("test");
    }

    //Patient Table Definition
    private const String TABLE_NAME_1 = "Patient";
    private const String KEY_PATIENT_ID = "PatientId";
    private const String KEY_NAME = "Name";
    
    //Score Table Definition
    private const String TABLE_NAME_2 = "Score";
    private const String KEY_ID = "Id";
    private const String KEY_SCORE_PATIENT_ID = "PatientId";
    private const String KEY_GAME_MODE = "GameMode";
    private const String KEY_TIME_TAKEN = "TimeTaken";

    public void InsertPatient(Patient patient)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText =
            "INSERT INTO " + TABLE_NAME_1
            + " ( "
            + KEY_PATIENT_ID + ", "
            + KEY_NAME + " ) "

            + "VALUES ( '"
            + null + "', '"             //AutoIncrement column
            + patient.Name + "' )";
        dbcmd.ExecuteNonQuery();
    }

    public void InsertScore(Score score)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText =
            "INSERT INTO " + TABLE_NAME_2
            + " ( "
            + KEY_ID + ", "
            + KEY_SCORE_PATIENT_ID + ", "
            + KEY_GAME_MODE + ", "
            + KEY_TIME_TAKEN + " ) "

            + "VALUES ( '"
            + null + "', '"                 //AutoIncrement column
            + score.PatientId + "', '"
            + score.GameMode + "', '"
            + score.TimeTaken + "' )";
        dbcmd.ExecuteNonQuery();
    }

    // public void addData(Patient patient){

    //     string query =  
    //         "INSERT INTO " + TABLE_NAME_1
    //         + " ( "
    //         + KEY_PATIENT_ID + ", "
    //         + KEY_NAME + " ) "

    //         + "VALUES ( '"
    //         + null + "', '"             //AutoIncrement column
    //         + patient.Name + "' )";

    //     var db_connection_string = "URI=file:" + Application.dataPath + "/" + database_name;

    //     SQLiteCommand a = new SQLiteCommand(query, db_connection_string);
    //     a.ExecuteNonQuery();
    // }
    public override IDataReader getDataById(int id)
    {
        return base.getDataById(id);
    }

}
