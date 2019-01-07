using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Pankaj Talwar #300986202
public class ClubRepository
{
    
    public ClubRepository()
    {

        //Pankaj Talwar #300986202
        Clubs_Data = new List<Club>();
    }
    
    public List<Club> Clubs_Data { get; set; }
}

//Pankaj Talwar #300986202