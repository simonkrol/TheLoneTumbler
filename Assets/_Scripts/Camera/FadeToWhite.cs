using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToWhite : MonoBehaviour {

	public Texture2D whiteTexture;
	public float fadeSpeed= 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;

	private int fadeDirection = -1;

	void OnGui(){ //unity render Gui functions
		alpha+= fadeDirection + fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a);
		GUI.depth = drawDepth;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), whiteTexture); 


	}


	public float BeginFade(int direction){
		fadeDirection = direction;
		print ("fade vales" + fadeSpeed);
		return (fadeSpeed);

	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player")
		{
			BeginFade (-1);
		}
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.F)){
			print ("HES TRYING");
			StartCoroutine (FadeUpdate ());
		}

	}

	IEnumerator FadeUpdate(){
		float fadeTime = BeginFade (-1);
		yield return new WaitForSeconds (fadeTime);
	}




}
