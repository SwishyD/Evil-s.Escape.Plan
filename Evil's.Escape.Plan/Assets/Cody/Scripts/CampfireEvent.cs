using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireEvent : MonoBehaviour {

    public GameObject campfireUI;
    public GameObject restUI;
    public GameObject trainUI;
    public GameObject p1UI;
    public GameObject p2UI;
    public GameObject p3UI;
    public GameObject trainCompleteUI;
    public GameObject backButtonUI;

    public void BackToMap()
    {
        Debug.Log("Returning to map...");
    }

    public void Rest()
    {
        campfireUI.SetActive(false);
        restUI.SetActive(true);
        trainUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(false);
        backButtonUI.SetActive(false);
        PartyManager.instance.p1.health = PartyManager.instance.p1.maxHealth;
        PartyManager.instance.p2.health = PartyManager.instance.p2.maxHealth;
        PartyManager.instance.p3.health = PartyManager.instance.p3.maxHealth;

    }

    public void Train()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(true);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(false);
        backButtonUI.SetActive(false);

    }

    public void TrainP1()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(true);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(false);
        backButtonUI.SetActive(true);
    }
    public void TrainP2()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(true);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(false);
        backButtonUI.SetActive(true);

    }
    public void TrainP3()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(true);
        trainCompleteUI.SetActive(false);
        backButtonUI.SetActive(true);

    }

    public void TrainP1Attack()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p1.attack += 1;
        backButtonUI.SetActive(false);


    }
    public void TrainP1Block()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p1.block += 1;
        backButtonUI.SetActive(false);

    }
    public void TrainP1Magic()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p1.magic += 1;
        backButtonUI.SetActive(false);

    }
    public void TrainP2Attack()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p2.attack += 1;
        backButtonUI.SetActive(false);
    }
    public void TrainP2Block()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p2.block += 1;
        backButtonUI.SetActive(false);
    }
    public void TrainP2Magic()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p2.magic += 1;
        backButtonUI.SetActive(false);
    }
    public void TrainP3Attack()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p3.attack += 1;
        backButtonUI.SetActive(false);
    }
    public void TrainP3Block()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p3.block += 1;
        backButtonUI.SetActive(false);
    }
    public void TrainP3Magic()
    {
        campfireUI.SetActive(false);
        trainUI.SetActive(false);
        restUI.SetActive(false);
        p1UI.SetActive(false);
        p2UI.SetActive(false);
        p3UI.SetActive(false);
        trainCompleteUI.SetActive(true);
        PartyManager.instance.p3.magic += 1;
        backButtonUI.SetActive(false);
    }

    
}
