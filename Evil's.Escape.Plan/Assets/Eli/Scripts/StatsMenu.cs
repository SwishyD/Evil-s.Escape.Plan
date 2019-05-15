using UnityEngine;
using UnityEngine.UI;

public enum Values
{
    Column01,
    Column02,
    Column03
};

[System.Serializable]
public class StatsOperations
{
    [Tooltip("Stats in Order")]
    public Values statNum;
}

public class StatsMenu : MonoBehaviour
{
    public StatsOperations[] statsOperations;

    [SerializeField]
    private StatsOperations _so = new StatsOperations();

    [SerializeField]
    private Button orcOne;
    [SerializeField]
    private Button orcTwo;
    [SerializeField]
    private Button orcThree;

    public GameObject popup;

    private bool selectedStat = false;
    private string currentTag;

    [SerializeField]
    private GameObject[] statsValues;
    // Search via Tag Attack, Defence, Magic. Then via Name 1, 2, 3
    [SerializeField]
    private Image currentButton;

    void Start()
    {
        currentTag = currentButton.tag;
    }

    public void ButtonClick()
    {
        switch (_so.statNum)
        {
            case Values.Column01:
                if (selectedStat == true)
                {
                    currentButton.color = new Color32(255, 255, 255, 150);
                    foreach (GameObject button in statsValues)
                    {
                        if (button.name == "4")
                        {
                            button.GetComponent<Button>().interactable = false;
                        }
                    }
                    currentButton.tag = currentTag;
                    selectedStat = false;
                }
                else if (selectedStat == false)
                {
                    currentButton.color = new Color32(248, 128, 0, 255);
                    foreach (GameObject button in statsValues)
                    {
                        if (button.name == "4")
                        {
                            button.GetComponent<Button>().interactable = true;
                        }
                    }
                    currentButton.tag = "Selected";
                    selectedStat = true;
                }
                break;
            case Values.Column02:
                if (selectedStat == true)
                {
                    currentButton.color = new Color32(255, 255, 255, 150);
                    foreach (GameObject button in statsValues)
                    {
                        if (button.name == "5")
                        {
                            button.GetComponent<Button>().interactable = false;
                        }
                    }
                    currentButton.tag = currentTag;
                    selectedStat = false;
                }
                else if (selectedStat == false)
                {
                    currentButton.color = new Color32(248, 128, 0, 255);
                    foreach (GameObject button in statsValues)
                    {
                        if (button.name == "5")
                        {
                            button.GetComponent<Button>().interactable = true;
                        }
                    }
                    currentButton.tag = "Selected";
                    selectedStat = true;
                }
                break;
            case Values.Column03:
                if (selectedStat == true)
                {
                    currentButton.color = new Color32(255, 255, 255, 150);
                    currentButton.tag = currentTag;
                    selectedStat = false;
                }
                else if (selectedStat == false)
                {
                    currentButton.color = new Color32(248, 128, 0, 255);
                    currentButton.tag = "Selected";
                    selectedStat = true;
                }
                break;
        }
    }

    public void orcOneStats()
    {
        orcTwo.enabled = true;
        orcThree.enabled = true;

        popup.SetActive(true);

        orcOne.enabled = false;
    }

    public void orcTwoStats()
    {
        orcOne.enabled = true;
        orcThree.enabled = true;

        popup.SetActive(true);

        orcTwo.enabled = false;
    }

    public void orcThreeStats()
    {
        orcOne.enabled = true;
        orcTwo.enabled = true;

        popup.SetActive(true);

        orcThree.enabled = false;
    }


}
