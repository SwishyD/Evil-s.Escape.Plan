using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentColor : MonoBehaviour
{
    public Image tableColor;
    public ColorPicker picker;

    void Start()
    {
        Color color2 = Color.white;
        picker.CurrentColor = color2;

        picker.onValueChanged.AddListener(color =>
        {
            tableColor.color = color;
        });
        tableColor.color = picker.CurrentColor;
    }
}
