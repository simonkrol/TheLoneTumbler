using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour {

    private const float Y_ANGLE_MIN = 5.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    Camera cam;

    private float distanceP2C = 2.5f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start() {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Mouse1)) {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    private void LateUpdate() {
		if(camTransform.transform != null){
        Vector3 direction = new Vector3(0, 0, -distanceP2C);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * direction;
        camTransform.LookAt(lookAt.position);
		}
    }

	public void setNewLookAt(Transform newLookAt){
		lookAt = newLookAt;

	}


}
