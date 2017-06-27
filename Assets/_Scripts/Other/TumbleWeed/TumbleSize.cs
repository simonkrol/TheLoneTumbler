using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleSize : MonoBehaviour {

	public float startSize = 1.0f;
	public float minSize = 0.001f;
	public float maxSize = 10.0f;

	public float speed = 1.0f;

	public float shrinkRate = 0.01f ;
	public float growthRate = 0.01f;

	private Vector3 targetScale;
	private Vector3 baseScale;
	private float currScale;

	public float deathSize;

	GameObject sporeMan;

	void Start() {
		baseScale = transform.localScale;
		transform.localScale = baseScale * startSize;
		currScale = startSize;
		targetScale = baseScale * startSize;



	}

	void Update() {
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);

		if (transform.localScale.x <= deathSize) {
			sporeMan = GameObject.FindGameObjectWithTag ("SporeManager");
			sporeMan.GetComponent<SporeManager> ().OnPlayerDeath ();
			//sporeMan.GetComponent<SporeManager> ().isPlayerDead = true;
			Destroy (this.gameObject);
		}

		// If you don't want an eased scaling, replace the above line with the following line
		//   and change speed to suit:
		// transform.localScale = Vector3.MoveTowards (transform.localScale, targetScale, speed * Time.deltaTime);

		//if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
		//	ChangeSize (false);
		//}

		if (Input.GetKey (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
			ChangeSize (false);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			ChangeSize (true);
		}







	}

	public void ChangeSize(bool bigger) {

		if (bigger)
			currScale+=growthRate;
		else
			currScale-=shrinkRate;

		currScale = Mathf.Clamp (currScale, minSize, maxSize+1);

		targetScale = baseScale * currScale;
	}   

	void OnCollisionEnter(Collision collisionInfo) {
		if(collisionInfo.gameObject.tag == "Cactus" ){
			print ("CACTUS");
			ChangeSize (false);
			ChangeSize (false);
			ChangeSize (false);
		}
	}

}
