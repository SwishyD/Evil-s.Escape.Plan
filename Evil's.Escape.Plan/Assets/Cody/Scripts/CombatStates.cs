using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStates : MonoBehaviour {

    public GameObject[] playerHealthbars;
    public GameObject[] enemyHealthbars;
    public GameObject[] playerShieldbars;
    public GameObject[] enemyShieldbars;
    public Text[] playerHealthText;
    public Text[] enemyHealthText;
    public Text[] playerNamesText;
    public Text[] enemyNamesText;


    public GameObject[] allyTargetUI;
    public GameObject[] enemyTargetUI;


    public Player[] players;
    public Enemy[] enemies;


    int currentIndex;
    public Player currentPlayer ;


    public GameObject combatUI;

    


    //STATES FOR THE STATE MACHINE\\
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,              
        COMBAT,
        LOSE,
        WIN,
        COMBATOVER
    }

    public BattleStates currentState;

	void Start ()
    {

        players = new Player[] { PartyManager.instance.p1, PartyManager.instance.p2, PartyManager.instance.p3 };
        enemies = GenerateEnemies();

        currentIndex = 0;

        currentState = BattleStates.START;
	}
	
	void Update ()
    {
        AssignUI();

        switch (currentState)
        {
            case (BattleStates.START):
                //RANDOM ENEMY GENERATION
                Debug.Log("COMBAT ENCOUNTER STARTED");
                for (int i = 0; i < allyTargetUI.Length; i++)
                {
                    allyTargetUI[i].SetActive(false);
                }
                for (int i = 0; i < enemyTargetUI.Length; i++)
                {
                    enemyTargetUI[i].SetActive(false);
                }
                currentState = BattleStates.PLAYERCHOICE;
                break;

            case (BattleStates.PLAYERCHOICE):
                currentPlayer = players[currentIndex];
                CheckHP();
                if (currentPlayer.health <= 0)
                {
                    currentPlayer.chosenMove = Creature.Move.DOWNED;
                    currentIndex++;
                }
               
                if (currentPlayer.isStunned == true && currentPlayer.chosenMove != Creature.Move.DOWNED)
                {
                    currentPlayer.chosenMove = Creature.Move.STUNNED;
                    currentIndex++;
                }
                if (currentIndex > 2)
                {
                    currentState = BattleStates.COMBAT;
                }
                
                combatUI.SetActive(true);
                break;
           

            case (BattleStates.COMBAT):
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].isStunned = false;
                }
                combatUI.SetActive(false);
                CombatResolution();          
                break;

            case (BattleStates.LOSE):
                GameOver();
                break;

            case (BattleStates.WIN):
                Win();
                break;
        }


	}

    void AssignUI()
    {
        for (int i = 0; i < playerHealthbars.Length; i++)
        {
            playerNamesText[i].text = players[i].name;
            playerHealthText[i].text = "" + players[i].health;
            playerHealthbars[i].GetComponent<Image>().fillAmount = players[i].health / players[i].maxHealth;
            playerShieldbars[i].GetComponent<Image>().fillAmount = players[i].shieldAmount / players[i].maxHealth;
        }
        for (int i = 0; i < enemyHealthbars.Length; i++)
        {
            enemyNamesText[i].text = enemies[i].name;
            enemyHealthText[i].text = "" + enemies[i].health;
            enemyHealthbars[i].GetComponent<Image>().fillAmount = enemies[i].health / enemies[i].maxHealth;
            enemyShieldbars[i].GetComponent<Image>().fillAmount = enemies[i].shieldAmount / enemies[i].maxHealth;
        }
    }

    Enemy[] GenerateEnemies()
    {
        Enemy[] enemies = new Enemy[3];
        for (int i = 0; i < 3; i++)
        {
            enemies[i] = Enemy.CreateBasicEnemy();
        }
        return enemies;
    }


    //**PLAYER CHOOSES ACTION**\\
    public void ShieldDefendAlly()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].health > 0)
            {
                allyTargetUI[i].SetActive(true);
            }
            else
            {
                allyTargetUI[i].SetActive(false);
            }
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyTargetUI[i].SetActive(false);
        }
        currentPlayer.chosenMove = Creature.Move.SHIELD;
        Debug.Log(currentPlayer.name + " chose SHIELD");
    }

    public void SwordAttack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].health > 0)
            {
                enemyTargetUI[i].SetActive(true);
            }
            else
            {
                enemyTargetUI[i].SetActive(false);
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            allyTargetUI[i].SetActive(false);
        }
        currentPlayer.chosenMove = Creature.Move.SWORD;
        Debug.Log(currentPlayer.name + " chose SWORD");
    }
   
    public void MagicAttack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].health > 0)
            {
                enemyTargetUI[i].SetActive(true);
            }
            else
            {
                enemyTargetUI[i].SetActive(false);
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            allyTargetUI[i].SetActive(false);
        }
        currentPlayer.chosenMove = Creature.Move.MAGIC;
        Debug.Log(currentPlayer.name + " chose MAGIC");
    }

   
    public void TargetEnemy(int target)
    {
        if (target < players.Length)
        {
            currentPlayer.chosenTarget = players[target];
        }
        else
        {
            currentPlayer.chosenTarget = enemies[target - players.Length];
        }
        for (int i = 0; i < enemyTargetUI.Length; i++)
        {
            enemyTargetUI[i].SetActive(false);
            allyTargetUI[i].SetActive(false);
        }
        if (currentIndex >= 2)
        {
            currentState = BattleStates.COMBAT;
        }
        else
        {
            currentIndex++;
        }
        Debug.Log(currentIndex);
       
    }
    
    //IF PLAYER WISHES TO UNDO A CHOICE BEFORE COMBAT\\

    public void Back()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        Debug.Log(currentIndex);
    }

    void CheckHP()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].health <= 0)
            {
                enemies[i].chosenMove = Creature.Move.DOWNED;
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].health <= 0)
            {
                players[i].chosenMove = Creature.Move.DOWNED;
            }
        }
    }

    void EnemyChooseTarget()
    {       
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy chosenEnemy = enemies[i];
            ChooseMoveForEnemy(chosenEnemy);
        }
    }

    private void ChooseMoveForEnemy(Enemy chosenEnemy)
    {
        if (chosenEnemy.chosenMove == Creature.Move.DOWNED || chosenEnemy.chosenMove == Creature.Move.INTERRUPTED || chosenEnemy.chosenMove == Creature.Move.STUNNED)
        {
            return;
        }
        if (players[0].health <= 0 && players[1].health <= 0 && players[2].health <= 0)
        {
            currentState = BattleStates.LOSE;
            return;
        }
        if (chosenEnemy.chosenMove == Creature.Move.SHIELD)
        {
            chosenEnemy.chosenTarget = enemies[Random.Range(0, 3)];
        }
        else if (chosenEnemy.chosenMove == Creature.Move.SWORD || chosenEnemy.chosenMove == Creature.Move.MAGIC)
        {
            chosenEnemy.chosenTarget = players[Random.Range(0, 3)];
        }
        if (chosenEnemy.chosenTarget.health <= 0)
        {
            ChooseMoveForEnemy(chosenEnemy);
        }
    }

    void AllyChangeTarget()
    {
        for (int i = 0; i < players.Length; i++)
        {
            Player chosenPlayer = players[i];
            ChooseTargetForAlly(chosenPlayer);
        }
    }

    private void ChooseTargetForAlly(Player chosenPlayer)
    {
        if (chosenPlayer.chosenMove == Creature.Move.DOWNED || chosenPlayer.chosenMove == Creature.Move.INTERRUPTED || chosenPlayer.chosenMove == Creature.Move.STUNNED)
        {
            return;
        }
        if (enemies[0].health <= 0 && enemies[1].health <= 0 && enemies[2].health <= 0)
        {
            currentState = BattleStates.WIN;
            return;
        }
        if (chosenPlayer.chosenMove == Creature.Move.SHIELD)
        {
            chosenPlayer.chosenTarget = players[Random.Range(0, 3)];

        }
        else if (chosenPlayer.chosenMove == Creature.Move.SWORD || chosenPlayer.chosenMove == Creature.Move.MAGIC)
        {
            chosenPlayer.chosenTarget = enemies[Random.Range(0, 3)];
        }
       
        if (chosenPlayer.chosenTarget.health <= 0)
        {
            ChooseTargetForAlly(chosenPlayer);
        }
    }

    void CombatResolution()
    {
        CheckHP();
        for (int i = 0; i < enemies.Length; i++)
        {
            int randomMove = Random.Range(0, 3);
            if (enemies[i].health > 0)
            {
                if (randomMove == 0)
                {
                    enemies[i].chosenMove = Creature.Move.SHIELD;

                }
                else if (randomMove == 1)
                {
                    enemies[i].chosenMove = Creature.Move.SWORD;
                }
                else if (randomMove == 2)
                {
                    enemies[i].chosenMove = Creature.Move.MAGIC;
                }
                EnemyChooseTarget();
                
                Debug.Log(enemies[i].name + " chose " + enemies[i].chosenMove + " and targeted " + enemies[i].chosenTarget.name);
            }
            else
            {
                enemies[i].chosenMove = Creature.Move.DOWNED;
            }

        }

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (players[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseTargetForAlly(players[i]);
            }
            if (players[i].chosenMove == Creature.Move.SHIELD)
            {
                players[i].chosenTarget.shieldAmount = players[i].block;
            }
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (enemies[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseMoveForEnemy(enemies[i]);
            }
            if (enemies[i].chosenMove == Creature.Move.SHIELD)
            {
                enemies[i].chosenTarget.shieldAmount = enemies[i].block;
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (players[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseTargetForAlly(players[i]);
            }
            if (players[i].chosenMove == Creature.Move.SWORD)
            {
                if (players[i].chosenTarget.shieldAmount > 0)
                {
                    players[i].chosenTarget.shieldAmount -= players[i].attack;
                    if(players[i].chosenTarget.shieldAmount >= 0)
                    {
                        players[i].isStunned = true;
                    }
                    else if(players[i].chosenTarget.shieldAmount < 0)
                    {
                        players[i].chosenTarget.health += players[i].chosenTarget.shieldAmount;
                    }                                        
                }
                else
                {
                    if (players[i].chosenTarget.chosenMove == Creature.Move.MAGIC)
                    {
                        players[i].chosenTarget.chosenMove = Creature.Move.INTERRUPTED;
                    }
                    players[i].chosenTarget.health -= players[i].attack;
                }
            }
            CheckHP();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (enemies[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseMoveForEnemy(enemies[i]);
            }
            if (enemies[i].chosenMove == Creature.Move.SWORD)
            {
                if (enemies[i].chosenTarget.shieldAmount > 0)
                {
                    enemies[i].chosenTarget.shieldAmount -= enemies[i].attack;
                    if (enemies[i].chosenTarget.shieldAmount >= 0)
                    {
                        enemies[i].isStunned = true;
                    }
                    else if (enemies[i].chosenTarget.shieldAmount < 0)
                    {
                        enemies[i].chosenTarget.health += enemies[i].chosenTarget.shieldAmount;
                    }
                }
                else
                {
                    if(enemies[i].chosenTarget.chosenMove == Creature.Move.MAGIC)
                    {
                        enemies[i].chosenTarget.chosenMove = Creature.Move.INTERRUPTED;
                    }
                    enemies[i].chosenTarget.health -= enemies[i].attack;
                }
            }
            CheckHP();
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (players[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseTargetForAlly(players[i]);
            }
            if (players[i].chosenMove == Creature.Move.MAGIC)
            {
                players[i].chosenTarget.health -= players[i].magic;
            }
            CheckHP();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].chosenMove == Creature.Move.DOWNED)
            {
                continue;
            }
            if (enemies[i].chosenTarget.chosenMove == Creature.Move.DOWNED)
            {
                ChooseMoveForEnemy(enemies[i]);
            }
            if (enemies[i].chosenMove == Creature.Move.MAGIC)
            {
                enemies[i].chosenTarget.health -= enemies[i].magic;
            }
            CheckHP();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log(enemies[i].health);
            Debug.Log(players[i].health);
        }
        CheckWinLose();


    }

  
   void CheckWinLose()
    {
        if (players[0].health <= 0 && players[1].health <= 0 && players[2].health <= 0)
        {
            currentState = BattleStates.LOSE;
        }
        else if (enemies[0].health <= 0 && enemies[1].health <= 0 && enemies[2].health <= 0)
        {
            currentState = BattleStates.WIN;
        }
        else
        {
            currentIndex = 0;
            currentState = BattleStates.PLAYERCHOICE;
        }
    }

   void Win()
    {
        Debug.Log("YOU WIN");
        currentState = BattleStates.COMBATOVER;
        for (int i = 0; i < enemies.Length; i++)
        {
            PartyManager.instance.goldCount += enemies[i].goldWorth;
            PartyManager.instance.partyXP += enemies[i].xpWorth;
        }
    }
    
   void GameOver()
    {
        Debug.Log("YOU LOSE");
        currentState = BattleStates.COMBATOVER;
    }
}
