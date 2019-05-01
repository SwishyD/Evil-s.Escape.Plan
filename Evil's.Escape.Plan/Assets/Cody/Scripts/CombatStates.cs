using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStates : MonoBehaviour {

    public GameObject[] targetsUI;

    public Player[] players;
    public Enemy[] enemies;


    int currentIndex;
    public Player currentPlayer;


    public GameObject combatUI;


    //STATES FOR THE STATE MACHINE\\
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,              
        COMBAT,
        LOSE,
        WIN
    }

    public BattleStates currentState;

	void Start ()
    {
        players = new Player[] { new Player(), new Player(), new Player() };
        enemies = new Enemy[] { new Enemy(), new Enemy(), new Enemy() };

        currentIndex = 0;
        currentState = BattleStates.START;
	}
	
	void Update ()
    {
        

        switch (currentState)
        {
            case (BattleStates.START):
                //RANDOM ENEMY GENERATION
                Debug.Log("COMBAT ENCOUNTER STARTED");
                currentState = BattleStates.PLAYERCHOICE;
                break;

            case (BattleStates.PLAYERCHOICE):
                currentPlayer = players[currentIndex];
                combatUI.SetActive(true);
               
               // Debug.Log("PLAYER 1 CHOICE");
                break;
           

            case (BattleStates.COMBAT):
                //ACTIONS CARRIED OUT BY BOTH TEAMS
               // Debug.Log("COMBAT RESOLVING");
                break;

            case (BattleStates.LOSE):
                //TRIGGER GAME OVER
               // Debug.Log("GAMEOVER");
                break;

            case (BattleStates.WIN):
                //SHOWS END OF BATTLE RESULTS THEN MOVES ON
               // Debug.Log("ENCOUNTER DEFEATED");
                break;
        }


	}




    //**PLAYER CHOOSES ACTION**\\
    public void ShieldAttack()
    {
        currentPlayer.chosenMove = Creature.Move.SHIELD;
        Debug.Log("SHIELD");
    }

    public void SwordAttack()
    {
        currentPlayer.chosenMove = Creature.Move.SWORD;
        Debug.Log("SWORD");
    }
   
    public void MagicAttack()
    {
        currentPlayer.chosenMove = Creature.Move.MAGIC;
        Debug.Log("MAGIC");
    }


    
    public void Target()
    {
        
    }


    //IF PLAYER WISHES TO UNDO A CHOICE BEFORE COMBAT\\

    public void Back()
    {
        if (currentIndex < 0)
        {
            currentIndex -= 1;
        }
    }

    void CombatResolution()
    {
        
    }
}
