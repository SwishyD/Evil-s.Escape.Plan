using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button quitButton;

    public GameObject popup;
    public GameObject settingsPopup;

    [SerializeField]
    private Button quit;
    private bool isQuitting = true;
    private int confirmQuit = 0;

    [SerializeField]
    private GameObject[] settingsObjects;
    public Button controlsTab;
    public Button settingsTab;
    private int selectedTab = 0;

    [SerializeField]
    private Button newGame;
    [SerializeField]
    private Button no;
    private bool statsOpen = false;
    private bool quitOpen = false;
    private bool quitAxisInUse = true;
    private bool axisInUse = false;
    
    public CanvasGroup stats;
    [SerializeField]
    private Animator anim;

    public StatsMenu statsMenu;

    void Start()
    {
        stats.alpha = 0;
        isQuitting = true;
        popup.SetActive(false);
        settingsPopup.SetActive(false);
        PauseTracker.roomCompletion = 0;
    }

    void Update()
    {
        if (!statsOpen)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (axisInUse == false)
                {
                    newGame.Select();
                    axisInUse = true;
                }
            }

            if (quitOpen == true)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    if (quitAxisInUse == false)
                    {
                        no.Select();
                        quitAxisInUse = true;
                    }
                }
            }
        }

        if (isQuitting == true)
        {
            if ((Input.GetKeyDown("escape")) && (confirmQuit == 0))
            {
                quit.Select();
                axisInUse = true;
                quitting();
            }
            else if ((Input.GetKeyDown("escape")) && (confirmQuit == 1))
            {
                axisInUse = false;
                cancel();
            }
        }

        if (selectedTab == 1)
        {
            foreach (GameObject x in settingsObjects)
            {
                if (x.tag == "ShowOnControls")
                {
                    x.SetActive(true);
                }

                else if (x.tag == "ShowOnSettings")
                {
                    x.SetActive(false);
                }
            }
        }
        else if (selectedTab == 2)
        {
            foreach (GameObject x in settingsObjects)
            {
                if (x.tag == "ShowOnControls")
                {
                    x.SetActive(false);
                }

                else if (x.tag == "ShowOnSettings")
                {
                    x.SetActive(true);
                }
            }
        }
    }

    public void assignStats()
    {
        AudioManager.instance.CancelMonster();
        FindObjectOfType<AudioManager>().Play("Button Click");
        statsOpen = true;
        stats.alpha = 1;
    }

    public void begin()
    {
        if (statsMenu.loadingReady)
        {
            AudioManager.instance.CancelBackground();
            AudioManager.instance.Monster(1);
            stats.alpha = 0;
            FindObjectOfType<AudioManager>().Play("New Game");
            Invoke("Loading", 1f);
        }
    }

    private void Loading()
    {
        bool isLoading = true;
        anim.SetBool("IsLoading", isLoading);
    }

    public void settings()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        axisInUse = true;
        isQuitting = false;
        settingsPopup.SetActive(true);

        settingsButton.enabled = false;
    }

    public void settingsCancel()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        axisInUse = false;
        isQuitting = true;
        settingsPopup.SetActive(false);

        settingsButton.enabled = true;
    }

    public void showControlsTab()
    {
        controlsTab.enabled = false;
        settingsTab.enabled = true;
        selectedTab = 1;
    }

    public void showSettingsTab()
    {
        controlsTab.enabled = true;
        settingsTab.enabled = false;
        selectedTab = 2;
    }

    public void quitting()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        quitOpen = true;

        quitAxisInUse = false;
        axisInUse = true;
        popup.SetActive(true);
        if (confirmQuit == 1)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        confirmQuit = 1;

        quitButton.enabled = false;
    }

    public void cancel()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        quitOpen = false;

        quitAxisInUse = true;
        axisInUse = false;
        popup.SetActive(false);
        confirmQuit = 0;

        quitButton.enabled = true;
    }
}
