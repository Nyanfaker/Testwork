using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Key : MonoBehaviour {

    public CanvasGroup cg;
    bool visualButton = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
            visualButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (visualButton)
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }
}
