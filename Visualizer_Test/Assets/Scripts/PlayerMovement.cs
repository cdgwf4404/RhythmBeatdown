using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 20.0f;
	public float jumpSpeed = 7.0f;
	public int maxJump = 2;
	public int jumpCount = 0;
	private bool isGrounded = true;
	private Rigidbody rb;
	bool rotate = false;
	public float crouch = 0.5f;
	
	public MeshRenderer[] death;
	public BoxCollider[] death2;
	public Rigidbody[] death3;
	/*void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }*/
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			transform.localScale = new Vector3(transform.localScale.x, crouch, transform.localScale.z);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			transform.localScale = new Vector3(transform.localScale.x, 0.75f, transform.localScale.z);
		}
		
		
		
		if (Input.GetKeyDown (KeyCode.RightArrow) && rotate == true) 
		{
			transform.RotateAround (transform.position, transform.up, 180f);
			rotate = false;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && rotate == false) 
		{
			transform.RotateAround(transform.position, transform.up, 180f);
			rotate = true;
		}
		
		var move = new Vector3 (Input.GetAxis ("Horizontal"), 0);
		GetComponent<Rigidbody> ().position += move * speed * Time.deltaTime;
		
		if (Input.GetKeyDown (KeyCode.Space) && jumpCount < maxJump) 
		{
			GetComponent<Rigidbody> ().velocity += Vector3.up * jumpSpeed;
			jumpCount++;
		}
		if (jumpCount > maxJump || isGrounded == false) 
		{
			jumpSpeed = 0.0f;
		}
		if (jumpCount > maxJump && isGrounded == true) 
		{
			jumpSpeed = 0.0f;
			jumpCount = 1;
		}
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Cubes") 
		{
			jumpCount = 0;
			jumpSpeed = 7.0f;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "Player") 
		{
			//StartCoroutine(respawn());
		}
	}
	
//	IEnumerator respawn()
//	{
//		if (gameObject.tag == "Player") 
//		{
//			death = gameObject.GetComponentsInChildren<MeshRenderer> ();
//			death2 = gameObject.GetComponentsInChildren<BoxCollider> ();
//			death3 = gameObject.GetComponentsInChildren<Rigidbody> ();
//			foreach(MeshRenderer mesh in death)
//				mesh.enabled = false;
//			foreach(BoxCollider mesh in death2)
//				mesh.enabled = false;
//			foreach(Rigidbody mesh in death3)
//				mesh.useGravity = false;
//			
//			yield return new WaitForSeconds(2);
//			
//			gameObject.transform.position = (GameObject.FindWithTag ("Spawn").transform.position);
//			foreach(MeshRenderer mesh in death)
//				mesh.enabled = true;
//			foreach(BoxCollider mesh in death2)
//				mesh.enabled = true;
//			foreach(Rigidbody mesh in death3)
//				mesh.useGravity = true;
//		}
//	}
}