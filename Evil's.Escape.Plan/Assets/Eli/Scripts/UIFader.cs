using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public CanvasGroup mainMenu;
    public CanvasGroup statsPanel;

    public StatsMenu statsMenu;

    void Update()
    {
        if (mainMenu.alpha == 0)
        {
            mainMenuPanel.SetActive(false);
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(mainMenu, mainMenu.alpha, 0));
    }

    public void StatsFadeOut()
    {
        if (statsMenu.loadingReady)
        {
            StartCoroutine(FadeCanvasGroup(statsPanel, statsPanel.alpha, 0));
        }
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
