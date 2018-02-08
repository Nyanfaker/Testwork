using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Door : MonoBehaviour {

    Player player;
    public CanvasGroup cg;
    public Animation textAnimation;
    public string text;
    bool visualButton = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player.Key)
            {
                cg.alpha = 1;
                cg.interactable = true;
                cg.blocksRaycasts = true;
                visualButton = true;
            }
            else
            {
                textAnimation.GetComponent<Text>().text = text;
                textAnimation.Play();
            }
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
