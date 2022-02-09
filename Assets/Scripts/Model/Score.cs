using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Score{
    public String PatientId;
    public char GameMode;
    public DateTime TimeTaken;
    
    public Score(String _PatientId, char _GameMode,DateTime _TimeTaken){
        PatientId = _PatientId;
        GameMode = _GameMode;
        TimeTaken = _TimeTaken;
    }


}