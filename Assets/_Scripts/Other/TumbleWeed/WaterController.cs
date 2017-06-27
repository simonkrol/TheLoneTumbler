using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

	GameObject sporeMan;
	// Update is called once per frame

	void OnTriggerEnter (Collider col)
    {
       	if(col.gameObject.tag=="Water")
       	{
			print ("Collission");
			sporeMan = GameObject.FindGameObjectWithTag ("SporeManager");
			sporeMan.GetComponent<SporeManager> ().OnPlayerDeath ();
			Destroy (this.gameObject);

       	}
    }

}
