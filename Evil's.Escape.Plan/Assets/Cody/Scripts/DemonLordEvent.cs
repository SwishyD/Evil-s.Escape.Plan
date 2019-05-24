using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLordEvent : MonoBehaviour {

    public GameObject questionUI;
    public GameObject yesUI;
    public GameObject noUI;

    public void Yes()
    {
        questionUI.SetActive(false);
        yesUI.SetActive(true);
        noUI.SetActive(false);
        PartyManager.instance.p1.maxHealth -= 30;
        PartyManager.instance.p2.maxHealth -= 30;
        PartyManager.instance.p3.maxHealth -= 30;
        PartyManager.instance.p1.attack += 10;
        PartyManager.instance.p2.attack += 10;
        PartyManager.instance.p3.attack += 10;
        PartyManager.instance.CheckMaxHp();
    }

    public void No()
    {
        questionUI.SetActive(false);
        yesUI.SetActive(false);
        noUI.SetActive(true);
        PartyManager.instance.p1.health -= 10;
        PartyManager.instance.p2.health -= 10;
        PartyManager.instance.p3.health -= 10;
    }

    public void BackToMap()
    {
        Debug.Log("Returning to map...");
    }
}
