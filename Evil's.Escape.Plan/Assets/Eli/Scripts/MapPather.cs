using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tiers
{
    Tier00,
    Tier01,
    Tier02,
    Tier03
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
    private Image[] yellowPathsOn;
    [SerializeField]
    private Image[] yellowPathsOff;
    [SerializeField]
    private Image[] greyPaths;
    [SerializeField]
    private GameObject[] locks;
    [SerializeField]
    private GameObject[] tierButtons;

    public void OnButtonClick()
    {
        switch (_to.tierNum)
        {
            case Tiers.Tier00:
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 0");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                foreach (GameObject lockImage in locks)
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
                }
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
                foreach (GameObject lockImage in locks)
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
                }
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
                foreach (GameObject lockImage in locks)
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
                }
                foreach (Button nextButton in nextButtons)
                {
                    nextButton.interactable = true;
                }
                break;
            case Tiers.Tier03:
                PauseTracker.roomCompletion++;
                tierButtons = GameObject.FindGameObjectsWithTag("Tier 3");
                foreach (GameObject button in tierButtons)
                {
                    button.GetComponent<Button>().interactable = false;
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
                }
                break;
        }
    }
}
