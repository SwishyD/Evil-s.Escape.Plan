using UnityEngine;
using UnityEngine.UI;

public class TableSelector : MonoBehaviour
{
    [SerializeField]
    private Button[] mainButtons;

    [SerializeField]
    private GameObject[] panels;

    [SerializeField]
    private Sprite[] outfits;
    [SerializeField]
    private Button[] outfitButtons;

    [SerializeField]
    private Sprite[] bodies;
    [SerializeField]
    private Button[] bodyButtons;

    [SerializeField]
    private Sprite[] legs;
    [SerializeField]
    private Button[] legButtons;

    [SerializeField]
    private Sprite[] gender;
    [SerializeField]
    private Button[] genderButtons;
    [SerializeField]
    private Image genderPopup;

    [SerializeField]
    private Text createdName;
    [SerializeField]
    private Text finalName;

    private ColorBlock cb;
    private Color disabled;
    private Color enabled;
    private Color normal;
    private Color standard;
    private Color black;

    public Image mainTable;
    public Image bodyTable;
    public Image legTable;

    public static TableSelector instance;
    [HideInInspector]
    public int hasTablecloth;

    [SerializeField]
    private Slider widthBody;
    [SerializeField]
    private Slider heightBody;
    [SerializeField]
    private Slider widthLegs;
    [SerializeField]
    private Slider heightLegs;
    private float widthBodyValue = 0.2f;
    private float heightBodyValue = 0.2f;
    private float widthLegsValue = 0.2f;
    private float heightLegsValue = 0.2f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        disabled = new Color32(255, 255, 255, 255);
        enabled = new Color32(255, 255, 255, 0);
        normal = new Color32(44, 44, 44, 255);
        standard = new Color32(145, 145, 145, 255);
        black = new Color32(0, 0, 0, 0);

        mainButtons[0].enabled = false;
        cb = mainButtons[0].colors;
        cb.normalColor = enabled;
        mainButtons[0].colors = cb;

        panels[0].SetActive(true);
        outfitButtons[0].enabled = false;
        bodyButtons[0].enabled = false;
        legButtons[0].enabled = false;
    }

    void Update()
    {
        finalName.text = createdName.text;

        widthBodyValue = (widthBody.value + 1) * 0.2f;
        heightBodyValue = (heightBody.value + 1) * 0.2f;

        bodyTable.rectTransform.localScale = new Vector2(widthBodyValue, heightBodyValue);

        widthLegsValue = (widthLegs.value + 1) * 0.2f;
        heightLegsValue = (heightLegs.value + 1) * 0.2f;

        legTable.rectTransform.localScale = new Vector2(widthLegsValue, heightLegsValue);
    }

    public void MainTabChange(int TabNum)
    {
        var value = TabNum;

        foreach (Button mb in mainButtons)
        {
            mb.enabled = true;
            cb = mb.colors;
            cb.normalColor = disabled;
            mb.colors = cb;
        }
        mainButtons[value].enabled = false;

        cb = mainButtons[value].colors;
        cb.normalColor = enabled;
        mainButtons[value].colors = cb;
    }

    public void PanelChange(int PanelNum)
    {
        var value = PanelNum;

        foreach (GameObject p in panels)
        {
            p.SetActive(false);
        }
        panels[value].SetActive(true);
    }

    public void OutfitChange(int TableNum)
    {
        var value = TableNum;

        bodyTable.sprite = bodies[value];
        legTable.sprite = legs[value];

        foreach (Button ob in outfitButtons)
        {
            ob.enabled = true;
        }
        outfitButtons[value].enabled = false;

        if (value <= 4)
        {
            hasTablecloth = 0;
            TableTracker(value);
        }
        else
        {
            hasTablecloth = 1;
            Tablecloth(value);
        }
    }

    public void TableTracker(int TableNum)
    {
        mainButtons[1].enabled = true;
        mainButtons[2].enabled = true;

        mainButtons[1].image.color = standard;
        mainButtons[2].image.color = standard;

        var value = TableNum;

        bodyTable.sprite = bodies[value];
        legTable.sprite = legs[value];

        foreach (Button bb in bodyButtons)
        {
            bb.enabled = true;
        }
        bodyButtons[value].enabled = false;

        foreach (Button lb in legButtons)
        {
            lb.enabled = true;
        }
        legButtons[value].enabled = false;
    }

    public void Tablecloth(int TableNum)
    {
        mainButtons[1].enabled = false;
        mainButtons[2].enabled = false;

        mainButtons[1].image.color = normal;
        mainButtons[2].image.color = normal;

        var value = TableNum;

        bodyTable.sprite = bodies[value];
        legTable.sprite = legs[value];

        foreach (Button bb in bodyButtons)
        {
            bb.enabled = true;
        }

        foreach (Button lb in legButtons)
        {
            lb.enabled = true;
        }
    }

    public void BodyChange(int TableNum)
    {
        foreach (Button ob in outfitButtons)
        {
            ob.enabled = true;
        }

        var value = TableNum;

        bodyTable.sprite = bodies[value];

        foreach (Button bb in bodyButtons)
        {
            bb.enabled = true;
        }
        bodyButtons[value].enabled = false;
    }

    public void LegChange(int TableNum)
    {
        foreach (Button ob in outfitButtons)
        {
            ob.enabled = true;
        }

        var value = TableNum;

        legTable.sprite = legs[value];

        foreach (Button lb in legButtons)
        {
            lb.enabled = true;
        }
        legButtons[value].enabled = false;
    }

    public void GenderChange(int GenderNum)
    {
        var value = GenderNum;

        genderPopup.sprite = gender[value];

        foreach (Button gb in genderButtons)
        {
            gb.enabled = true;
            cb = gb.colors;
            cb.normalColor = black;
            gb.colors = cb;
        }
        genderButtons[value].enabled = false;

        cb = genderButtons[value].colors;
        cb.normalColor = normal;
        genderButtons[value].colors = cb;
    }
}
