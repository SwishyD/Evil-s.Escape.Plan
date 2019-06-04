using UnityEngine;

public class Name : MonoBehaviour
{
    public GameObject detailsPanel;

    void Start()
    {
        detailsPanel.SetActive(false);
    }

    public void pointerStay()
    {
        detailsPanel.SetActive(true);
    }

    public void pointerLeave()
    {
        detailsPanel.SetActive(false);
    }
}