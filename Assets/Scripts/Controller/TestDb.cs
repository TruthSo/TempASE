using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DatabaseController dbcontext = new DatabaseController();
        dbcontext.SelectAllPatients();
        dbcontext.SelectPatientById(2);

        Patient patient_a = new Patient("Bolo");
        dbcontext.AddPatient(patient_a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
