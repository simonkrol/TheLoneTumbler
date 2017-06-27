//	CameraFacing.cs 
//	original by Neil Carter (NCarter)
//	modified by Hayden Scott-Baron (Dock) - http://starfruitgames.com
//  allows specified orientation axis
 
 
using UnityEngine;
using System.Collections;
 
public class PlaneManager : MonoBehaviour
{

 
	void  Update ()
	{
		// rotates the object relative to the camera

		transform.LookAt(Camera.main.transform.position, -Vector3.up);
		transform.Rotate (90,0,0);
	}
}