using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeKey : MonoBehaviour {

    public Animation textAnimation;
    public string text;
    public GameObject key;
    public CanvasGroup cg;

    public void TakeKeyButton()
    {
        FindObjectOfType<Player>().Key = true;
        Destroy(key);

        textAnimation.GetComponent<Text>().text = text;
        textAnimation.Play();

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        Destroy(GameObject.Find("Event_Key").gameObject);
    }
}
