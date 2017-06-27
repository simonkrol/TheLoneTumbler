using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());

	}
	
}
