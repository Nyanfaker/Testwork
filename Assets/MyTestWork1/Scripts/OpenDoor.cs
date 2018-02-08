using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public Animation open;
    public CanvasGroup cg;

    public void OpenDoorButton()
    {
        open.Play();

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        Destroy(GameObject.Find("Event_Door"));
    }
}
