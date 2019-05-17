using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public Orc[] orcs;

    [SerializeField]
    private Button orcOne;
    [SerializeField]
    private Button orcTwo;
    [SerializeField]
    private Button orcThree;

    private int currentOrc;
    public StatsManager statsManager;

    [HideInInspector]
    public bool nextPopup;
    [HideInInspector]
    public bool previousPopup;
    public Text nextText;
    [SerializeField]
    private Button previousButton;
    public Text previousText;

    [HideInInspector]
    public int previousAttack;
    [HideInInspector]
    public int previousDefence;
    [HideInInspector]
    public int previousMagic;

    private ColorBlock cb;
    private Color selected;
    private Color notSelected;

    [HideInInspector]
    public bool loadingReady = false;

    void Start()
    {
        currentOrc = 1;
        selected = new Color32(255, 255, 255, 255);
        notSelected = new Color32(255, 255, 255, 65);

        cb = orcOne.GetComponent<Button>().colors;
        cb.disabledColor = selected;
        orcOne.GetComponent<Button>().colors = cb;
    }

    void Update()
    {
        if (currentOrc == 1)
        {
            OrcSelected(orcOne);
            previousButton.interactable = false;
            previousText.color = new Color32(125, 48, 44, 128);
        }
        else
        {
            OrcNotSelected(orcTwo);
            OrcNotSelected(orcThree);
            previousButton.interactable = true;
            previousText.color = new Color32(125, 48, 44, 255);
        }

        if (currentOrc == 2)
        {
            OrcSelected(orcTwo);
        }
        else
        {
            OrcNotSelected(orcOne);
            OrcNotSelected(orcThree);
        }

        if (currentOrc == 3)
        {
            OrcSelected(orcThree);
            nextText.text = "Confirm";
        }
        else
        {
            OrcNotSelected(orcOne);
            OrcNotSelected(orcTwo);
            nextText.text = "Next";
        }
    }

    public void StatsRecorder()
    {
        if (nextText.text.Equals("Confirm"))
        {
            loadingReady = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Button Click");
            Orc orcCurrent = orcs.First(o => o.orcNum == currentOrc);
            Orc orcTarget = orcs.First(o => o.orcNum == currentOrc + 1);
            if (currentOrc <= 3)
            {
                orcCurrent.orcName = statsManager.nameInput.text;
                orcCurrent.orcAttack = statsManager.attackStats.Count();
                orcCurrent.orcDefence = statsManager.defenceStats.Count();
                orcCurrent.orcMagic = statsManager.magicStats.Count();

                if ((currentOrc < 3) && (previousPopup == false))
                {
                    currentOrc++;
                    Debug.Log("Orc is " + currentOrc);
                    nextPopup = true;
                }
                else
                {
                    currentOrc++;
                    Debug.Log("Orc is " + currentOrc);
                }
            }

            if (!orcTarget.orcName.Equals(""))
            {
                statsManager.nameInput.text = orcTarget.orcName;
                previousAttack = orcTarget.orcAttack + 2;
                previousDefence = orcTarget.orcDefence + 2;
                previousMagic = orcTarget.orcMagic + 2;

                previousPopup = true;
            }
            else
            {
                if ((orcTarget.orcAttack != 0) || (orcTarget.orcDefence != 0) || (orcTarget.orcMagic != 0))
                {
                    statsManager.nameInput.text = "";
                    previousAttack = orcTarget.orcAttack + 2;
                    previousDefence = orcTarget.orcDefence + 2;
                    previousMagic = orcTarget.orcMagic + 2;

                    previousPopup = true;
                }

                statsManager.nameInput.text = "";
            }
        }
    }

    public void StatsPrevious()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Orc orcCurrent = orcs.First(o => o.orcNum == currentOrc);
        Orc orcTarget = orcs.First(o => o.orcNum == currentOrc - 1);
        if (currentOrc <= 3)
        {
            orcCurrent.orcName = statsManager.nameInput.text;
            orcCurrent.orcAttack = statsManager.attackStats.Count();
            orcCurrent.orcDefence = statsManager.defenceStats.Count();
            orcCurrent.orcMagic = statsManager.magicStats.Count();

            statsManager.nameInput.text = orcTarget.orcName;
            previousAttack = orcTarget.orcAttack + 2;
            previousDefence = orcTarget.orcDefence + 2;
            previousMagic = orcTarget.orcMagic + 2;

            if (currentOrc > 1)
            {
                currentOrc--;
                Debug.Log("Orc is now " + currentOrc);
                previousPopup = true;
            }
        }
    }

    public void OrcSelected(Button orc)
    {
        cb = orc.GetComponent<Button>().colors;
        cb.disabledColor = selected;
        orc.GetComponent<Button>().colors = cb;
    }

    public void OrcNotSelected(Button orc)
    {
        cb = orc.GetComponent<Button>().colors;
        cb.disabledColor = notSelected;
        orc.GetComponent<Button>().colors = cb;
    }
}
