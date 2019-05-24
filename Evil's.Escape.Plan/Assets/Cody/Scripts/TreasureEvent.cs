using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureEvent : MonoBehaviour {

    public GameObject treasureUI;
    public GameObject powerChosenUI;
    public GameObject wealthChosenUI;
    public Text powerText;

    int playerChosen;
    int randomStat;



    public void Start ()
    {
        playerChosen = Random.Range(0, 3);
        randomStat = Random.Range(0, 3);        
	}
    

    public void BackToMap()
    {
        Debug.Log("Returning to map...");
    }
    public void Power()
    {
       

        if (playerChosen == 0)
        {
            if (randomStat == 0)
            {
                powerText.text = PartyManager.instance.p1.name + "'s weapon glows with energy! Attack Increased!";
                Debug.Log("p1 attack increased");
                PartyManager.instance.p1.attack += 1;
            }
            else if (randomStat == 1)
            {
                powerText.text = PartyManager.instance.p1.name + " feels their defenses grow stronger! Block Increased!";

                Debug.Log("p1 block increased");

                PartyManager.instance.p1.block += 1;
            }
            else if (randomStat == 2)
            {
                powerText.text = PartyManager.instance.p1.name + " feels mystical energy pulsing through their veins! Magic Increased!";

                Debug.Log("p1 magic increased");

                PartyManager.instance.p1.magic += 1;
            }
        }
        else if (playerChosen == 1)
        {
            if (randomStat == 0)
            {
                powerText.text = PartyManager.instance.p2.name + "'s weapon glows with energy! Attack Increased!";
                Debug.Log("p2 attack increased");

                PartyManager.instance.p2.attack += 1;
            }
            else if (randomStat == 1)
            {
                powerText.text = PartyManager.instance.p2.name + " feels their defenses grow stronger! Block Increased!";
                Debug.Log("p2 block increased");

                PartyManager.instance.p2.block += 1;
            }
            else if (randomStat == 2)
            {
                powerText.text = PartyManager.instance.p2.name + " feels mystical energy pulsing through their veins! Magic Increased!";
                Debug.Log("p2 magic increased");

                PartyManager.instance.p2.magic += 1;
            }
        }
        else if (playerChosen == 2)
        {
            if (randomStat == 0)
            {
                powerText.text = PartyManager.instance.p3.name + "'s weapon glows with energy! Attack Increased!";
                Debug.Log("p3 attack increased");

                PartyManager.instance.p3.attack += 1;
            }
            else if (randomStat == 1)
            {
                powerText.text = PartyManager.instance.p3.name + " feels their defenses grow stronger! Block Increased!";
                Debug.Log("p3 block increased");

                PartyManager.instance.p3.block += 1;
            }
            else if (randomStat == 2)
            {
                powerText.text = PartyManager.instance.p2.name + " feels mystical energy pulsing through their veins! Magic Increased!";
                Debug.Log("p3 magic increased");

                PartyManager.instance.p3.magic += 1;
            }
        }
        wealthChosenUI.SetActive(false);
        treasureUI.SetActive(false);
        powerChosenUI.SetActive(true);
    }

    public void Wealth()
    {
        wealthChosenUI.SetActive(true);
        treasureUI.SetActive(false);
        powerChosenUI.SetActive(false);
        PartyManager.instance.goldCount += 10;
    }
	
    public void Continue()
    {
        BackToMap();
    }
	
}
