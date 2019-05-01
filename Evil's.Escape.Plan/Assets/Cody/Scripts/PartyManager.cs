using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour {

    public Player p1;
    public Player p2;
    public Player p3;

    private void Start()
    {
        p1 = new Player();
        p2 = new Player();
        p3 = new Player();
    }

}
