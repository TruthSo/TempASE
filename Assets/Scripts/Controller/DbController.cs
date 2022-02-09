using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbController : MonoBehaviour{
    void Start (){

        LinkItDbContext dbContext = new LinkItDbContext();

        Debug.Log("add data");

        //test data
        Patient patient = new Patient();
        patient.Name = "Wen";

        dbContext.InsertPatient(patient);

        Debug.Log("get data id 1");
        var aa = dbContext.getDataById(1);
        
        
        Debug.Log("test xx: ",aa.Read()[0]);
        dbContext.close();


    }
}