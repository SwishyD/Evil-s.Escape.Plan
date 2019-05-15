using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
    private bool isPaused;

    [SerializeField]
    private GameObject gameMap;

    [SerializeField]
    private Button resume;
    [SerializeField]
    private Button no;
    private bool quitOpen;
    private bool quitAxisInUse;
    private bool axisInUse;

    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        isPaused = false;
        hidePaused();
        gameMap.SetActive(false);
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

        if ((Input.GetKeyDown(KeyCode.M)) && isPaused != true)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                gameMap.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                gameMap.SetActive(false);
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
        Time.timeScale = 1;
        isPaused = false;
        foreach (GameObject objs in pauseObjects)
        {
            objs.SetActive(false);
        }
    }

    public void settings()
    {
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
        if (confirmRestart == 1)
        {
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
