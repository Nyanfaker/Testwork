using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour {

    CanvasGroup cg;
    Player2 player2;
    Text textEvent;
    Slider slider;

    bool filling = false;

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        player2 = FindObjectOfType<Player2>();
        textEvent = GameObject.Find("TextEvent").GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.gameObject.SetActive(false);
    }

    public void Event()
    {
        if (!player2.Canister)
        {
            player2.Canister = true;
            Destroy(GameObject.Find("Oilcan2").gameObject);
            Destroy(GameObject.Find("Event_Canister").gameObject);
            StartCoroutine(Canister());
            return;
        }
        if (!player2.Full && !filling)
        {
            StartCoroutine(Filling("Event_Fuel", "Canister is full"));
            return;
        }
        if (player2.Full && !player2.Refuel && !filling)
        {
            StartCoroutine(Filling("Event_Car", "Car is full"));
            return;
        }
    }

    IEnumerator Canister()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        textEvent.text = "Сanister is raised";
        textEvent.enabled = true;
        yield return new WaitForSeconds(2f);
        textEvent.enabled = false;
    }

    IEnumerator Filling(string name, string text)
    {
        filling = true;
        textEvent.text = "Filling";
        textEvent.enabled = true;

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        slider.gameObject.SetActive(true);
        slider.value = 0;
        while (slider.value < 1)
        {
            slider.value += Time.deltaTime;
            yield return null;
        }
        slider.gameObject.SetActive(false);

        if (!player2.Full)
        {
            player2.Full = true;
        } else
        {
            player2.Refuel = true;
        }
        
        Destroy(GameObject.Find(name).gameObject);
        textEvent.text = text;
        yield return new WaitForSeconds(2f);
        textEvent.enabled = false;
        filling = false;
    }

    public void Cancel()
    {
        StopAllCoroutines();
        filling = false;
        textEvent.enabled = false;
        slider.gameObject.SetActive(false);
    }
}
