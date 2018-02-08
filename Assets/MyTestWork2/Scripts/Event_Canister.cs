using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Canister : MonoBehaviour {

    public CanvasGroup cg;
    bool visualButton = false;
    public string text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
            visualButton = true;
            cg.GetComponentInChildren<Text>().text = text;
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
