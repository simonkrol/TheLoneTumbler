using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {


	public Camera playerCam;
	public Camera endCam1;
	public bool gameover = false;

	// Use this for initialization
	void Start () {

		playerCam.enabled = true;
		endCam1.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SwapCam(){
		gameover = true;
		endCam1.enabled = true;

	}



}
