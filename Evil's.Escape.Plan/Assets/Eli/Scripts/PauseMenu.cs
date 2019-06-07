using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button menuButton;
    [SerializeField]
    private Button quitButton;

    public GameObject popup;
    public GameObject settingsPopup;
    private int confirmQuit = 0;
    private int confirmRestart = 0;

    [SerializeField]
    private GameObject[] settingsObjects;
    public Button controlsTab;
    public Button settingsTab;
    private int selectedTab = 0;

    public GameObject[] pauseObjects;
    [HideInInspector]
    public bool isPaused = false;

    [SerializeField]
    private Button resume;
    [SerializeField]
    private Button no;
    private bool quitOpen = false;
    private bool quitAxisInUse = true;
    private bool axisInUse = false;

    private bool shortcutKey;

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
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        isPaused = false;
        shortcutKey = true;
        hidePaused();
        popup.SetActive(false);
        settingsPopup.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                isPaused = true;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                isPaused = false;
                shortcutKey = true;
                hidePaused();
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (axisInUse == false)
            {
                resume.Select();
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

    public void showPaused()
    {
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(true);
        }
    }
    
    public void hidePaused()
    {
        if (!shortcutKey)
        {
            FindObjectOfType<AudioManager>().Play("Button Click");
        }

        Time.timeScale = 1;
        isPaused = false;
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(false);
        }

        shortcutKey = false;
    }

    public void settings()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        axisInUse = true;
        settingsPopup.SetActive(true);
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(false);
        }

        optionsButton.enabled = false;
    }

    public void settingsCancel()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        axisInUse = false;
        settingsPopup.SetActive(false);
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(true);
        }

        optionsButton.enabled = true;
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

    public void menu()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        quitOpen = true;

        quitAxisInUse = false;
        axisInUse = true;
        popup.SetActive(true);
        confirmRestart = 1;
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(false);
        }

        menuButton.enabled = false;
    }

    public void quitting()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        quitOpen = true;

        quitAxisInUse = false;
        axisInUse = true;
        popup.SetActive(true);
        confirmQuit = 1;
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(false);
        }

        quitButton.enabled = false;
    }

    public void confirm()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        if (confirmRestart == 1)
        {
            AudioManager.instance.CancelBackground();
            AudioManager.instance.Background(false, true);
            AudioManager.instance.Monster(0);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (confirmQuit == 1)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void cancel()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        quitOpen = false;

        quitAxisInUse = true;
        axisInUse = false;
        popup.SetActive(false);
        confirmRestart = 0;
        confirmQuit = 0;
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(true);
        }

        menuButton.enabled = true;
        quitButton.enabled = true;
    }
}
