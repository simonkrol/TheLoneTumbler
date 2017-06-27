using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplashControl : MonoBehaviour {
    public GameObject splash;
    private float realtime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        splash.transform.Translate(Vector3.down * Time.deltaTime*10);
        realtime += Time.deltaTime;
       
    

        if (realtime >= 5)
        {
            splash.SetActive(false);
        }

    }
}
