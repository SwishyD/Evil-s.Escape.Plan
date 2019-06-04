using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tiers
{
    Tier00,
    Tier01,
    Tier02,
    Tier03,
    Tier04,
    Tier05,
    Tier06,
    Tier07,
    Tier08
};

[System.Serializable]
public class TierOperations
{
    [Tooltip("Tier Number")]
    public Tiers tierNum;

    [Tooltip("Number in Tier")]
    public int orderInTier;
}

public class MapPather : MonoBehaviour
{
    public TierOperations[] tierOperations;

    [SerializeField]
    private TierOperations _to = new TierOperations();

    [SerializeField]
    private Button[] nextButtons;
    [SerializeField]
    private GameObject[] yellowPathsOn;
    [SerializeField]
    private GameObject[] yellowPathsOff;
    [SerializeField]
    private GameObject[] greyPaths;
    [SerializeField]
    private GameObject[] tierButtons;
    [SerializeField]
    private Text thisText;

    public void OnButtonClick()
    {
        Debug.Log("Working");
        switch (_to.tierNum)
        {
            case Tiers.Tier00:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 0");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                foreach (GameObject yellowOn in yellowPathsOn)
                {
                    IEnumerable<Image> images = yellowOn.GetComponentsInChildren<Image>();
                    foreach (Image im in images)
                    {
                        im.color = new Color32(255, 226, 31, 255);
                    }
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier01:
                PauseTracker.roomCompletion++;
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 1");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image yellow in yellowPathsOff)
                {
                    var tempYellow = yellow.color;
                    tempYellow.a = 0.5f;
                    yellow.color = tempYellow;
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier02:
                PauseTracker.roomCompletion++;
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 2");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image yellow in yellowPathsOff)
                {
                    var tempYellow = yellow.color;
                    tempYellow.a = 0.5f;
                    yellow.color = tempYellow;
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier03:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 3");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier04:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 4");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier05:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 5");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier06:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 6");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier07:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 7");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier08:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 8");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                /*foreach (GameObject lockImage in locks)
                {
                    lockImage.SetActive(false);
                }
                foreach (Image yellow in yellowPathsOn)
                {
                    yellow.color = new Color32(255, 226, 31, 255);
                }
                foreach (Image grey in greyPaths)
                {
                    grey.color = new Color32(64, 64, 64, 127);
                }*/
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
        }
    }

    public void GenerateRoom()
    {
        if (thisText.text.Equals("Battle"))
        {
            FindObjectOfType<AudioManager>().Play("Danger");
        }
        else if (thisText.text.Equals("Random"))
        {
            MapRandomize.instance.repickRoom(thisText);
        }
    }
}
