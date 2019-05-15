using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("Button Hover");
    }

    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("Button Hover");
    }
}
