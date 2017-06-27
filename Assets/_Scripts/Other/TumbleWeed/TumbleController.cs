using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleController : MonoBehaviour {



	public float speed;
	private Rigidbody rb;
	public float jumpHeight;

	public GameObject branchPrefab;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();


	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){


		
		float moveHorizontal =  Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

		movement = Camera.main.transform.TransformDirection (movement);

		rb.AddForce(movement * speed);

		/*
		float randTwig = Random.Range (0.0f , 1.0f);
		float randangle = Random.Range (0.0f , 1.0f);
		if(randTwig > 0.98f){
			print ("TWIG");
			GameObject tempBranch = Instantiate(branchPrefab,rb.transform.localPosition, Random.rotation)as GameObject;
		}*/


	}



	void OnTriggerEnter(Collider collisionInfo) {
		if(collisionInfo.gameObject.tag == "Finish" ){

			print ("End");
			collisionInfo.gameObject.GetComponent<Finish> ().SwapCam ();
		}
	}


}
