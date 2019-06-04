using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject warningPanel1;
    public GameObject warningPanel2;

    void Start()
    {
        warningPanel1.SetActive(false);
        warningPanel2.SetActive(false);
    }

    public void pointerStay1()
    {
        if (TableSelector.instance.hasTablecloth == 1)
        {
            warningPanel1.SetActive(true);
        }
    }

    public void pointerLeave1()
    {
        warningPanel1.SetActive(false);
    }

    public void pointerStay2()
    {
        if (TableSelector.instance.hasTablecloth == 1)
        {
            warningPanel2.SetActive(true);
        }
    }

    public void pointerLeave2()
    {
        warningPanel2.SetActive(false);
    }
}