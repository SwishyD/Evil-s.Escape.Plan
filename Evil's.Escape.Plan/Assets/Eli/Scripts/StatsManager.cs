using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allStats;

    private int statsAvailable = 3;
    private int stats = 0;
    private bool selectable = true;

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

    [HideInInspector]
    public GameObject[] attackStats;
    [HideInInspector]
    public GameObject[] defenceStats;
    [HideInInspector]
    public GameObject[] magicStats;

    public StatsMenu statsMenu;
    private bool ready = false;
    [SerializeField]
    private Button nextButton;
    public InputField nameInput;

    void Start()
    {
        orange = new Color32(250, 175, 7, 255);
        white = new Color32(255, 255, 255, 150);
        disabled = new Color32(200, 200, 200, 255);
        working = new Color32(200, 200, 200, 128);
    }

    void Update()
    {
        GameObject[] selected = allStats.Where(b => b.tag == "Selected").ToArray();
        GameObject[] selectable = allStats.Where(b => b.tag == "Selectable").ToArray();
        GameObject[] notSelectable = allStats.Where(b => b.tag == "Unselectable").ToArray();
        attackStats = selected.Where(b => b.name.Contains("Attack")).ToArray();
        defenceStats = selected.Where(b => b.name.Contains("Defence")).ToArray();
        magicStats = selected.Where(b => b.name.Contains("Magic")).ToArray();

        stats = selected.Count();
        statsAvailableText.text = (statsAvailable - stats) + " Points Available!!";

        if (stats >= statsAvailable)
        {
            foreach (GameObject button in selectable)
            {
                button.GetComponent<Button>().interactable = false;
            }
            if (!nameInput.text.Equals(""))
                ready = true;
            else
                ready = false;
        }
        else
        {
            foreach (GameObject button in selectable)
            {
                button.GetComponent<Button>().interactable = true;
            }
            ready = false;
        }

        if (!ready)
        {
            nextButton.interactable = false;
            statsMenu.nextText.color = new Color32(125, 48, 44, 128);
        }
        else
        {
            nextButton.interactable = true;
            statsMenu.nextText.color = new Color32(125, 48, 44, 255);
        }

        if (statsMenu.nextPopup)
        {
            foreach (GameObject button in selected)
            {
                buttonReset(button);
            }
            foreach (GameObject button in selectable)
            {
                buttonReset(button);
            }
            foreach (GameObject button in notSelectable)
            {
                buttonReset(button);
            }

            statsMenu.nextPopup = false;
        }

        if (statsMenu.previousPopup)
        {
            var attack = statsMenu.previousAttack;
            var defence = statsMenu.previousDefence;
            var magic = statsMenu.previousMagic;

            foreach (GameObject button in allStats)
            {
                button.GetComponent<Image>().color = white;
                cb = button.GetComponent<Button>().colors;
                cb.disabledColor = working;
                cb.highlightedColor = orange;
                button.GetComponent<Button>().colors = cb;

                button.tag = "Unselectable";
                button.GetComponent<Button>().interactable = false;

                var value = button.name;
                var split = value.Split(' ');
                var buttonType = split[0];
                var buttonValue = int.Parse(split[1]);

                if (buttonType == "Attack")
                {
                    if (buttonValue <= attack)
                    {
                        reactivateButton(button);
                    }
                    else if (buttonValue == attack + 1)
                    {
                        button.tag = "Selectable";
                        button.GetComponent<Button>().interactable = false;
                    }

                    if (attack == 4)
                    {
                        if (buttonValue == 3)
                        {
                            reactivateColor(button);
                        }
                    }
                    else if (attack == 5)
                    {
                        if (buttonValue <= 4)
                        {
                            reactivateColor(button);
                        }
                    }
                }
                if (buttonType == "Defence")
                {
                    if (buttonValue <= defence)
                    {
                        reactivateButton(button);
                    }
                    else if (buttonValue == defence + 1)
                    {
                        button.tag = "Selectable";
                        button.GetComponent<Button>().interactable = false;
                    }

                    if (defence == 4)
                    {
                        if (buttonValue == 3)
                        {
                            reactivateColor(button);
                        }
                    }
                    else if (defence == 5)
                    {
                        if (buttonValue <= 4)
                        {
                            reactivateColor(button);
                        }
                    }
                }
                if (buttonType == "Magic")
                {
                    if (buttonValue <= magic)
                    {
                        reactivateButton(button);
                    }
                    else if (buttonValue == magic + 1)
                    {
                        button.tag = "Selectable";
                        button.GetComponent<Button>().interactable = false;
                    }

                    if (magic == 4)
                    {
                        if (buttonValue == 3)
                        {
                            reactivateColor(button);
                        }
                    }
                    else if (magic == 5)
                    {
                        if (buttonValue <= 4)
                        {
                            reactivateColor(button);
                        }
                    }
                }
            }

            statsMenu.previousPopup = false;
        }
    }

    private void reactivateColor(GameObject button)
    {
        cb = button.GetComponent<Button>().colors;
        cb.disabledColor = disabled;
        button.GetComponent<Button>().colors = cb;
        button.GetComponent<Button>().interactable = false;
    }

    private void reactivateButton(GameObject button)
    {
        button.GetComponent<Image>().color = orange;
        cb = button.GetComponent<Button>().colors;
        cb.highlightedColor = white;
        button.GetComponent<Button>().colors = cb;
        button.tag = "Selected";
        button.GetComponent<Button>().interactable = true;
    }

    private void buttonReset(GameObject button)
    {
        button.GetComponent<Image>().color = white;
        cb = button.GetComponent<Button>().colors;
        cb.disabledColor = working;
        cb.highlightedColor = orange;
        button.GetComponent<Button>().colors = cb;

        if (button.name.Contains("3"))
        {
            button.tag = "Selectable";
            button.GetComponent<Button>().interactable = true;
        }
        else
        {
            button.tag = "Unselectable";
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void ButtonTagger(string ButtonKey)
    {
        var value = ButtonKey;
        var split = value.Split('-');
        var buttonType = split[0];
        var buttonValue = int.Parse(split[1]);

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
