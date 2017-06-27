using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SporeManager : MonoBehaviour {


	ArrayList  tumbleChildren;
	public bool isPlayerDead = false;

	GameObject player ;

	public GameObject tumbleWeedPrefab;
	public GameObject seedPrefab;
	public GameObject flowerPrefab;
	public Finish finish;

	private float growTimer = 0.0f;
	public float growTimeCap = 3.0f;

	public Material normalMat;
	public Material selectedMat;

	private int currentSeedIndex = 0;

	private GameObject tSeed ;

	// Use this for initialization
	void Start () {
		tumbleChildren = new ArrayList ();
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Q) && !isPlayerDead) { //plant a new seed add it to array
                                                             //GameObject tempSeed = (GameObject)Instantiate(seedPrefab);
            
            if(tumbleChildren.Count!=0) currentSeedIndex++;
            Vector3 seedPos = new Vector3(player.transform.localPosition.x,player.transform.localPosition.y+0.25f,player.transform.localPosition.z);
			GameObject tempSeed = Instantiate(seedPrefab,seedPos, seedPrefab.transform.rotation)as GameObject;
			AddChild (tempSeed);
            print(tumbleChildren.Count);

		}

		if(isPlayerDead){ // check if the player is dead so we can cycle through the array
//			print("WE THERE BOYS");
			if(Input.GetKeyDown(KeyCode.LeftArrow)){ // move left in array
				if (currentSeedIndex == 0) {
					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = normalMat;

					currentSeedIndex = tumbleChildren.Count-1;


					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = selectedMat;
					Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tSeed.GetComponent<Transform> ());

				} else {
					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = normalMat;

					currentSeedIndex--;

					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = selectedMat;
					Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tSeed.GetComponent<Transform> ());

				}
		
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){ //move right in array
				if (currentSeedIndex == tumbleChildren.Count-1) {

					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = normalMat;

					currentSeedIndex = 0;

					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = selectedMat;
					Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tSeed.GetComponent<Transform> ());

				} else {
					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = normalMat;

					currentSeedIndex++;

					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					tSeed.GetComponent<Renderer> ().material = selectedMat;
					Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tSeed.GetComponent<Transform> ());
				}


			}

			if(Input.GetKey(KeyCode.Space)){ //hold to grow
				growTimer += Time.deltaTime;
				if (growTimer >= growTimeCap) {

					tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
					Vector3 spawnPos = new Vector3 (tSeed.transform.localPosition.x,tSeed.transform.localPosition.y + 2, tSeed.transform.localPosition.z);

					GameObject tempTumble = Instantiate(tumbleWeedPrefab,spawnPos, tSeed.transform.localRotation)as GameObject;
					player = GameObject.FindGameObjectWithTag("Player");
					Destroy (tSeed.gameObject);
					tumbleChildren.RemoveAt (currentSeedIndex);
					Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tempTumble.GetComponent<Transform> ());
					//id we remove the max index location then we will be one short
					//instantiate a new player model at the position of the currently seleted seed
					//print ("WE GROWING BOYS");


					for (int i = 0; i < tumbleChildren.Count; i++) {
						tSeed =	(GameObject)tumbleChildren [i];
						GameObject tempFlower = Instantiate(flowerPrefab,tSeed.transform.localPosition, tSeed.transform.localRotation)as GameObject;
						Destroy(tSeed.gameObject);
					}


					growTimer = 0;
					isPlayerDead = false;
					tumbleChildren.Clear();
					currentSeedIndex = 0;
				}
			}


		}


		
	}

	void AddChild(GameObject tumbleChild){
		tumbleChildren.Add (tumbleChild);
	}

	public void OnPlayerDeath(){
		isPlayerDead = true;
		if (tumbleChildren.Count > 0) {
			tSeed =	(GameObject)tumbleChildren [currentSeedIndex];
			tSeed.GetComponent<Renderer> ().material = selectedMat;
			Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (tSeed.GetComponent<Transform> ());
		} else {
		//	GameObject phalus =  GameObject.FindGameObjectWithTag("Phalacti");
		//	Camera.main.GetComponent<ThirdPersonCam> ().setNewLookAt (phalus.GetComponent<Transform>());
			if(!finish.gameover){
				SceneManager.LoadScene ("Start");
			}
		}
		//THERES NO CHILDREN YOU DUNCE!!!


		//call the camera and pass it the new transfprm of the seed it needs to be looking at
	}




}
