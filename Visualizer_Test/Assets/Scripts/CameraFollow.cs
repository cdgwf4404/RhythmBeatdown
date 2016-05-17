/*using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;            // The position that that camera will be following.
	public float smoothing = 5f;        // The speed with which the camera will be following.



	Vector3 offset;                     // The initial offset from the target.
	
	void Start ()
	{
		// Calculate the initial offset.
		offset = transform.position - target.position;
	}
	
	void FixedUpdate ()
	{
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = target.position + offset;
		
		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
*/

using UnityEngine;
using System.Collections;

//Jorey's basic camera stuff
public class CameraFollow : MonoBehaviour {
	public GameObject triggerArea;
	public bool leaveArea = false;
	public Vector3 brawlStage;
	public GameObject character;
	public Vector3 characterPos;
	public float camSpeed = 2f;
	// Use this for initialization
	void Start () {

		brawlStage =  new Vector3(triggerArea.transform.position.x,1,-10);

	}

	// Update is called once per frame
	void Update () {

		if (StaticVar.leaveArea == true) {

			characterPos = new Vector3 (character.transform.position.x, 1, -10);
			this.transform.position = characterPos;
			StaticVar.leaveArea = false;
		}
		if (StaticVar.CamStop == false) {

			GetComponent<Rigidbody>().velocity = Vector3.right*camSpeed;

		} else if (StaticVar.CamStop == true) {
			this.transform.position = brawlStage;
			//stop cam
		}

	}
}
