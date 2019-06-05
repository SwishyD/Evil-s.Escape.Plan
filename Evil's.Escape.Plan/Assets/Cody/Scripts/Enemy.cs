using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{   
    public int xpWorth;
    public int goldWorth;
    static int number = 0;

    public static Enemy CreateBasicEnemy()
    {
        Enemy workingEnemy = new Enemy();
        workingEnemy.name = "GRUNT" + number++;
        workingEnemy.maxHealth = 10;
        workingEnemy.health = 10;
        workingEnemy.attack = 3;
        workingEnemy.block = 2;
        workingEnemy.magic = 4;
        workingEnemy.goldWorth = 5;
        workingEnemy.xpWorth = 100;
        return workingEnemy;
    }
}
