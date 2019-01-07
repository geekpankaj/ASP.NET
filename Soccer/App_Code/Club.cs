
//Pankaj Talwar #300986202
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Club
{
    public string clubName
    {
        get;
        set;
    }
    public string Clubcity
    {
        get;
        set;
}

    //Pankaj Talwar #300986202
    public string clubadd
    {
        get;        set;
    }
    public int clubregno { get; set; }
    public List<Players> Player { get; set; }
    public Club()
    {
        Player = new List<Players>();   
    }
    public void Add_player(Players Plyer)
    {
        Player.Add(Plyer);
    }
}

//Pankaj Talwar #300986202