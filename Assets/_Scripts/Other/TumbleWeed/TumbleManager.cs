using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleManager : MonoBehaviour {

	GameObject start;
	public GameObject tumbleWeedPrefab;
	private float multiplier;
	private Vector3 movement;
	public int maxTumble;
	private int totalTumble;
	ArrayList  tumbles;
	// Use this for initialization
	void Start () {
		totalTumble=0;
		tumbles = new ArrayList ();
		start = GameObject.FindGameObjectWithTag("Start");
		movement=new Vector3(10, -2, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(totalTumble<maxTumble)
		{
			if(Random.Range(1,40)==5)
			{
				Vector3 tumbleStart = new Vector3(start.transform.localPosition.x-1200,start.transform.localPosition.y-100,start.transform.localPosition.z+Random.Range(1,100));
				GameObject tempTumble = Instantiate(tumbleWeedPrefab,tumbleStart,tumbleWeedPrefab.transform.rotation)as GameObject;
				AddChild (tempTumble);
				totalTumble++;
			}
		}
		foreach(GameObject tumble in tumbles )
		{

			multiplier=(float)(1+(Random.Range(0,10)/10.0));
			tumble.GetComponent<Rigidbody>().AddForce(movement*multiplier);
		
  		
		}
	}
	void AddChild(GameObject tumble){
		tumbles.Add (tumble);
	}
	void OnCollisionEnter (Collision col)
    {
        tumbles.Remove(col.gameObject);
        Destroy(col.gameObject);
        totalTumble--;
    }
}
