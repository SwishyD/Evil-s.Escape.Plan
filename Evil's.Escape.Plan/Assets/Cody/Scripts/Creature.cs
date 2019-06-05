using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature
{
    public string name;
    public float maxHealth;
    public float health;
    public int attack;
    public int block;
    public int shieldAmount;
    public int magic;
    public Creature chosenTarget;
    public bool isStunned;
    public Move chosenMove;


    public enum Move
    {
        SHIELD,
        SWORD,
        MAGIC,
        INTERRUPTED,
        STUNNED,
        DOWNED
    }
}
