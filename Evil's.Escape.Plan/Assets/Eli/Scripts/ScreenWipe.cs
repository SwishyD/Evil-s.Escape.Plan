using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    [SerializeField]
    [Range(.1f, 5f)]
    private float wipeSpeed = 1f;

    private Image image;

    private enum WipeMode { NotBlocked, WipingToNotBlocked, Blocked, WipingToBlocked }

    private WipeMode wipeMode = WipeMode.NotBlocked;

    private float wipeProgress;

    public bool isDone { get; private set; }

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    public void ToggleWipe(bool blockScreen)
    {
        isDone = false;
        if (blockScreen)
            wipeMode = WipeMode.WipingToBlocked;
        else
            wipeMode = WipeMode.WipingToNotBlocked;
    }

    private void Update()
    {
       switch(wipeMode)
       {
            case WipeMode.WipingToBlocked:
                WipeToBlocked();
                break;
            case WipeMode.WipingToNotBlocked:
                WipeToNotBlocked();
                break;
       }
    }

    private void WipeToBlocked()
    {
        wipeProgress += Time.deltaTime * (1f / wipeSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress >= 1f)
        {
            isDone = true;
            wipeMode = WipeMode.Blocked;
        }
    }

    private void WipeToNotBlocked()
    {
        wipeProgress -= Time.deltaTime * (1f / wipeSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress <= 0)
        {
            isDone = true;
            wipeMode = WipeMode.NotBlocked;
        }
    }
}
