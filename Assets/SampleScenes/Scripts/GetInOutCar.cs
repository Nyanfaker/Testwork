using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetInOutCar : MonoBehaviour , IPointerClickHandler {

	public bool clicked;

	// Use this for initialization
	public void OnPointerClick(PointerEventData data) {
		if (!clicked)
			StartCoroutine ("ClickedCoroutine");
	}
	
	// Update is called once per frame
	IEnumerator ClickedCoroutine () {
		clicked = true;
		yield return new WaitForSeconds (0.1f);
		clicked = false;
	}
}
