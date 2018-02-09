using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_LevelCar : MonoBehaviour {

    public Animation levelComp;
    public CanvasGroup cgContinue;
    public CanvasGroup cgMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            StartCoroutine(LevelComplite());
        }
    }

    IEnumerator LevelComplite()
    {
        levelComp.Play();
        yield return new WaitForSeconds(1f);
        cgContinue.alpha = 1;
        cgContinue.interactable = true;
        cgContinue.blocksRaycasts = true;
        cgMenu.alpha = 1;
        cgMenu.interactable = true;
        cgMenu.blocksRaycasts = true;
        Time.timeScale = 0;
    }
}
