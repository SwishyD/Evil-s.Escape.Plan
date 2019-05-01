using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature
{
    public string name;
    public int health;
    public int attack;
    public int block;
    public int magic;

    public enum Move
    {
        SHIELD,
        SWORD,
        MAGIC
    }
}
