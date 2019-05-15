using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allStats;

    private int statsAvailable = 3;
    private int stats;
    private bool selectable;

    [SerializeField]
    private Text statsAvailableText;

    private ColorBlock cb;
    private Color orange;
    private Color white;
    private Color disabled;
    private Color working;

    private int AttackStart = 0;
    private int DefenseStart = 3;
    private int MagicStart = 6;

    void Start()
    {
        orange = new Color32(248, 128, 0, 255);
        white = new Color32(255, 255, 255, 150);
        disabled = new Color32(200, 200, 200, 255);
        working = new Color32(200, 200, 200, 150);
    }

    void Update()
    {
        GameObject[] selected = allStats.Where(b => b.tag == "Selected").ToArray();
        GameObject[] notSelectable = allStats.Where(b => b.tag == "Selectable").ToArray();

        stats = selected.Count();
        statsAvailableText.text = (statsAvailable - stats) + " Points Available!!";

        if (stats >= statsAvailable)
        {
            foreach (GameObject button in notSelectable)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            foreach (GameObject button in notSelectable)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ButtonTagger(string ButtonKey)
    {
        var value = ButtonKey;
        var split = value.Split('-');
        var buttonType = split[0];
        var buttonValue = int.Parse(split[1]);

        GameObject[] selected = allStats.Where(b => b.tag == "Selected").ToArray();

        if (stats < statsAvailable)
        {
            selectable = true;
            if (selectable == true)
            {
                if (buttonType == "Attack")
                {
                    ModifyStats(AttackStart, buttonValue);
                }
                if (buttonType == "Defence")
                {
                    ModifyStats(DefenseStart, buttonValue);
                }
                if (buttonType == "Magic")
                {
                    ModifyStats(MagicStart, buttonValue);
                }
            }
        }

        if (stats >= statsAvailable)
        {
            selectable = false;
            if (selectable == false)
            {
                if (buttonType == "Attack")
                {
                    RevertStats(AttackStart, buttonValue);
                }
                if (buttonType == "Defence")
                {
                    RevertStats(DefenseStart, buttonValue);
                }
                if (buttonType == "Magic")
                {
                    RevertStats(MagicStart, buttonValue);
                }
            }
        }
    }

    private void RevertStats(int startValue, int buttonValue)
    {
        if (buttonValue == 1)
        {
            if (allStats[startValue].tag == "Selected")
            {
                allStats[startValue].GetComponent<Image>().color = white;
                CurrentUnselected(startValue);
                allStats[startValue + 1].GetComponent<Button>().interactable = false;
                allStats[startValue + 1].tag = "Unselectable";
                allStats[startValue].tag = "Selectable";
            }
        }
        else if (buttonValue == 2)
        {
            if (allStats[startValue + 1].tag == "Selected")
            {
                allStats[startValue + 1].GetComponent<Image>().color = white;
                CurrentUnselected(startValue + 1);
                Enabled(startValue);
                allStats[startValue + 2].GetComponent<Button>().interactable = false;
                allStats[startValue + 2].tag = "Unselectable";
                allStats[startValue + 1].tag = "Selectable";
            }
        }
        else if (buttonValue == 3)
        {
            if (allStats[startValue + 2].tag == "Selected")
            {
                allStats[startValue + 2].GetComponent<Image>().color = white;
                CurrentUnselected(startValue + 2);
                Enabled(startValue + 1);
                allStats[startValue + 2].tag = "Selectable";
            }
        }
    }

    private void ModifyStats(int startValue, int buttonValue)
    {
        if (buttonValue == 1)
        {
            if (allStats[startValue].tag != "Selected")
            {
                allStats[startValue].GetComponent<Image>().color = orange;
                CurrentSelected(startValue);
                allStats[startValue + 1].GetComponent<Button>().interactable = true;
                allStats[startValue + 1].tag = "Selectable";
                allStats[startValue].tag = "Selected";
            }
            else if (allStats[startValue].tag == "Selected")
            {
                RevertStats(startValue, buttonValue);
            }
        }
        else if (buttonValue == 2)
        {
            if (allStats[startValue + 1].tag != "Selected")
            {
                allStats[startValue + 1].GetComponent<Image>().color = orange;
                CurrentSelected(startValue + 1);
                Disabled(startValue);
                allStats[startValue + 2].GetComponent<Button>().interactable = true;
                allStats[startValue + 2].tag = "Selectable";
                allStats[startValue + 1].tag = "Selected";
            }
            else if (allStats[startValue + 1].tag == "Selected")
            {
                RevertStats(startValue, buttonValue);
            }
        }
        else if (buttonValue == 3)
        {
            if (allStats[startValue + 2].tag != "Selected")
            {
                allStats[startValue + 2].GetComponent<Image>().color = orange;
                CurrentSelected(startValue + 2);
                Disabled(startValue + 1);
                allStats[startValue + 2].tag = "Selected";
            }
            else if (allStats[startValue + 2].tag == "Selected")
            {
                RevertStats(startValue, buttonValue);
            }
        }
    }

    public void CurrentUnselected(int currentButton)
    {
        cb = allStats[currentButton].GetComponent<Button>().colors;
        cb.highlightedColor = orange;
        allStats[currentButton].GetComponent<Button>().colors = cb;
    }

    public void CurrentSelected(int currentButton)
    {
        cb = allStats[currentButton].GetComponent<Button>().colors;
        cb.highlightedColor = white;
        allStats[currentButton].GetComponent<Button>().colors = cb;
    }

    public void Disabled(int currentButton)
    {
        cb = allStats[currentButton].GetComponent<Button>().colors;
        cb.disabledColor = disabled;
        allStats[currentButton].GetComponent<Button>().colors = cb;
        allStats[currentButton].GetComponent<Button>().interactable = false;
    }

    public void Enabled(int currentButton)
    {
        cb = allStats[currentButton].GetComponent<Button>().colors;
        cb.disabledColor = working;
        allStats[currentButton].GetComponent<Button>().colors = cb;
        allStats[currentButton].GetComponent<Button>().interactable = true;
    }
}
