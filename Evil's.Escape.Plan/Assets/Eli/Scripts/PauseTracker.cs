using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseTracker : MonoBehaviour
{
    public static int roomCompletion;
    [SerializeField]
    private Text roomTracker;
    
	void Start ()
    {
        roomTracker.text = "0 Rooms Completed";
	}
	
	void Update ()
    {
        roomTracker.text = roomCompletion + " Rooms Completed";
	}
}
