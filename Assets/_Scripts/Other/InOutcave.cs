using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutcave : MonoBehaviour {
    public GameObject inCavesound;
    public GameObject outCaveSound;

    bool toggle = true; 
   

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "cave")
        {
            //print("TEST");
            inCavesound.SetActive(toggle);
            outCaveSound.SetActive(!toggle);
            toggle = !toggle;
        }
    }
}
