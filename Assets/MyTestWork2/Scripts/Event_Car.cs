using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Car : MonoBehaviour {

    Text textEvent;
    Player2 player2;

    private void Start()
    {
        textEvent = GameObject.Find("TextEvent").GetComponent<Text>();
        player2 = FindObjectOfType<Player2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!player2.Canister && !player2.Full)
            {
                textEvent.text = "In the car there is no fuel, find the canister and fuel.";
                textEvent.enabled = true;
                return;
            }
            else if (player2.Canister && !player2.Full)
            {
                textEvent.text = "There is no fuel in the canister, find fuel.";
                textEvent.enabled = true;
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textEvent.enabled = false;
    }
}
