using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Fuel : MonoBehaviour {

    public CanvasGroup cg;
    bool visualButton = false;
    public string text;
    Text textEvent;

    private void Start()
    {
        textEvent = GameObject.Find("TextEvent").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player2 player2 = other.GetComponent<Player2>();
            if (!player2.Canister)
            {
                textEvent.text = "You need to find a canister";
                textEvent.enabled = true;
                return;
            }
            
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
            visualButton = true;
            cg.GetComponentInChildren<Text>().text = text;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textEvent.enabled = false;
        FindObjectOfType<EventButton>().Cancel();
        if (visualButton)
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }
}
