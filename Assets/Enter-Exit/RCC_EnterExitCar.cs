using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.CrossPlatformInput;

public class RCC_EnterExitCar : MonoBehaviour {

	private CarController carController;
	private GameObject carCamera;
	private GameObject player;
	public Transform getOutPosition;

	public bool isPlayerIn = false;
	private bool  opened = false;
	private float waitTime = 1f;
	private bool  temp = false;

	private GetInOutCar getInOutCar;

	void Awake (){

		carController = GetComponent<CarController>();
		carCamera = GameObject.FindObjectOfType<AutoCam>().gameObject;

		if(!getOutPosition){
			GameObject getOutPos = new GameObject("Get Out Position");
			getOutPos.transform.SetParent(transform);
			getOutPos.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
			getOutPos.transform.localRotation = Quaternion.identity;
			getOutPosition = getOutPos.transform;
		}

		getInOutCar = FindObjectOfType<GetInOutCar> ();
	}
	
	void Update (){

		if(getInOutCar.clicked && opened && !temp){
			GetOut();
			opened = false;
			temp = false;
		}

		if(!isPlayerIn)
			carController.GetComponent<CarUserControl>().enabled = false;

		if (handBrake > 0f)
			carController.Move (0f,0f,brake,handBrake);

	}
	
	IEnumerator Act (GameObject fpsplayer){
		
		player = fpsplayer;

		if (!opened && !temp){
			GetIn();
			opened = true;
			temp = true;
			yield return new WaitForSeconds(waitTime);
			temp = false;
		}

	}
	
	void GetIn (){

		isPlayerIn = true;

		carCamera.SetActive(true);

		carCamera.transform.GetComponent<AutoCam>().SetTarget(transform);
		player.transform.SetParent(transform);
		player.transform.localPosition = Vector3.zero;
		player.transform.localRotation = Quaternion.identity;
		player.SetActive(false);

		carController.GetComponent<CarUserControl>().enabled = true;
		
		Cursor.lockState = CursorLockMode.None;

	}
	
	void GetOut (){

		isPlayerIn = false;

		player.transform.SetParent(null);
		player.transform.position = getOutPosition.position;
		player.transform.rotation = getOutPosition.rotation;
		player.transform.rotation = Quaternion.Euler (0f, player.transform.eulerAngles.y, 0f);
		carCamera.SetActive(false);
		player.SetActive(true);

		StartCoroutine("BrakeGetOut");

		carController.GetComponent<CarUserControl>().enabled = false;
		
		Cursor.lockState = CursorLockMode.Locked;

	}

	float brake;
	float handBrake;

	IEnumerator BrakeGetOut() {
		brake = -1f;
		handBrake = 1f;
		yield return new WaitForSeconds (1f);
		brake = 0f;
		yield return new WaitForSeconds (4f);
		handBrake = 0f;
		carController.Move (0f,-1f,-1f,0f);
		carController.Move (0f,0f,0f,0f);
	}
	
}