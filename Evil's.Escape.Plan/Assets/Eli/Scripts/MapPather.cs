using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Image thisImage;

    public void OnButtonClick()
    {
        if (!PauseMenu.instance.isPaused)
        {
            Debug.Log("Working");
            switch (_to.tierNum)
            {
                case Tiers.Tier00:
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 0");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier01:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 1");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier02:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 2");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier03:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 3");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier04:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 4");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier05:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 5");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier06:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 6");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier07:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 7");
                    MapButtons();
                    foreach (Button nextButton in nextButtons)
                    {
                        nextButton.interactable = true;
                    }
                    break;
                case Tiers.Tier08:
                    PauseTracker.roomCompletion++;
                    tierButtons = GameObject.FindGameObjectsWithTag("Tier 8");
                    MapButtons();
                    break;
            }
        }
    }

    public void MapButtons()
    {
        foreach (GameObject button in tierButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        foreach (GameObject yellowOn in yellowPathsOn)
        {
            foreach (Transform child in yellowOn.transform)
            {
                child.gameObject.GetComponent<Image>().color = new Color32(255, 226, 31, 255);
            }
            /*IEnumerable<Image> images = yellowOn.GetComponentsInChildren<Image>();
            foreach (Image im in images)
            {
                im.color = new Color32(255, 226, 31, 255);
            }*/
        }
        foreach (GameObject yellow in yellowPathsOff)
        {
            foreach (Transform child in yellow.transform)
            {
                var tempYellow = child.gameObject.GetComponent<Image>().color;
                tempYellow.a = 0.5f;
                child.gameObject.GetComponent<Image>().color = tempYellow;
            }
        }
        foreach (GameObject grey in greyPaths)
        {
            foreach (Transform child in grey.transform)
            {
                child.gameObject.GetComponent<Image>().color = new Color32(64, 64, 64, 127);
            }
        }
    }

    public void GenerateRoom()
    {
        if (!PauseMenu.instance.isPaused)
        {
            if (thisImage.sprite == MapRandomize.instance.rooms[0])
            {
                Debug.Log("Battle Room is Loading");
                //SceneManager.LoadScene("Battle");
                FindObjectOfType<AudioManager>().Play("Danger");
            }
            else if (thisImage.sprite == MapRandomize.instance.rooms[1])
            {
                Debug.Log("Campfire Room is Loading");
                //SceneManager.LoadScene("Campfire");
            }
            else if (thisImage.sprite == MapRandomize.instance.rooms[2])
            {
                Debug.Log("Treasure Room is Loading");
                //SceneManager.LoadScene("Treasure");
            }
            else if (thisImage.sprite == MapRandomize.instance.rooms[3])
            {
                Debug.Log("Demon Room is Loading");
                //SceneManager.LoadScene("Demon");
            }
            else if (thisImage.sprite == MapRandomize.instance.rooms[4])
            {
                MapRandomize.instance.repickRoom(thisImage);
            }
        }
    }
}
