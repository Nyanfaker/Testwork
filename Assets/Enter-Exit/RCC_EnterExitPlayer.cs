using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.CrossPlatformInput;

public class RCC_EnterExitPlayer : MonoBehaviour {

	public PlayerType playerType;
	public enum PlayerType{FPS, TPS}

	public GameObject rootOfPlayer;
	public float maxRayDistance= 2f;
	public float rayHeight = 1f;
	public GameObject TPSCamera;
	private bool showGui = false;

	private GetInOutCar getInOutCar;

    Player2 player2;

	void Start(){

        player2 = GetComponent<Player2>();
 
		if (!rootOfPlayer)
			rootOfPlayer = transform.root.gameObject;

		GameObject carCamera = FindObjectOfType<AutoCam>().gameObject;
		carCamera.SetActive(false);

		getInOutCar = FindObjectOfType<GetInOutCar> ();
	}
	
	void Update (){
		
		Vector3 direction= transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + (playerType == PlayerType.TPS ? rayHeight : 0f), transform.position.z), direction, out hit, maxRayDistance)){

			if(hit.transform.GetComponentInParent<RCC_EnterExitCar>()){

                if (!player2.Canister || !player2.Full || !player2.Refuel)
                {
                    return;
                }

                showGui = true;

				if ( getInOutCar.clicked) {

					hit.transform.GetComponentInParent<CarController>().SendMessage("Act", rootOfPlayer, SendMessageOptions.DontRequireReceiver);
					
				}

			}else{

				showGui = false;

			}
			
		}else{

			showGui = false;

		}
        getInOutCar.gameObject.SetActive (showGui);
		
	}

	void OnDrawGizmos(){

		Gizmos.color = Color.red;
		Gizmos.DrawRay (new Vector3(transform.position.x, transform.position.y + (playerType == PlayerType.TPS ? rayHeight : 0f), transform.position.z), transform.forward * maxRayDistance);
		
	}

	void OnEnable(){

		if (TPSCamera)
			TPSCamera.SetActive (true);

	}

	void OnDisable(){

		if (TPSCamera)
			TPSCamera.SetActive (false);

	}
	
}