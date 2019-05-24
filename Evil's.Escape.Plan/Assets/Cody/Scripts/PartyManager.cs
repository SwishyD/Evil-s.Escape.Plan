using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour {

    public Player p1;
    public Player p2;
    public Player p3;

    public int goldCount;
    public int partyXP;
    public int partyLevel;     

    public static PartyManager instance = null;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        p1 = new Player();
        p2 = new Player();
        p3 = new Player();

        p1.name = "Gobta";
        p1.maxHealth = 10;
        p1.health = 10;
        p1.attack = 3;
        p1.block = 2;
        p1.magic = 4;

        p2.name = "Gooby";
        p2.maxHealth = 10;
        p2.health = 10;
        p2.attack = 5;
        p2.block = 2;
        p2.magic = 2;

        p3.name = "Gobbo";
        p3.maxHealth = 10;
        p3.health = 10;
        p3.attack = 2;
        p3.block = 4;
        p3.magic = 3;
    }

    public void CheckMaxHp()
    {
        if(p1.health > p1.maxHealth)
        {
            p1.health = p1.maxHealth;
        }
        if (p2.health > p2.maxHealth)
        {
            p2.health = p2.maxHealth;
        }
        if (p3.health > p3.maxHealth)
        {
            p3.health = p3.maxHealth;
        }
    }
}
