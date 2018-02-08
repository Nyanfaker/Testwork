using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour {

    public Animation color;
    public CanvasGroup cg;
    public Animation levelComp;

    public CanvasGroup cgContinue;
    public CanvasGroup cgMenu;

    public void PushButtonButton()
    {
        color.Play();

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        Destroy(GameObject.Find("Event_Button"));

        StartCoroutine(LevelComplite());
    }

    IEnumerator LevelComplite()
    {
        yield return new WaitForSeconds(1.1f);
        levelComp.Play();
        yield return new WaitForSeconds(0.5f);
        cgContinue.alpha = 1;
        cgContinue.interactable = true;
        cgContinue.blocksRaycasts = true;
        cgMenu.alpha = 1;
        cgMenu.interactable = true;
        cgMenu.blocksRaycasts = true;
        Time.timeScale = 0;
    }
}
