using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseLook : MonoBehaviour {

	// Use this for initialization
    public enum RotationAxes { MouseX, MouseY}
    public RotationAxes axes = RotationAxes.MouseY;

    private float currentSensivity_X = 1.5f;
    private float currentSensivity_Y = 1.5f;

    private float sensivity_X = 1.5f;
    private float sensivity_Y = 1.5f;

    private float rotation_X, rotation_Y;

    private float minimum_X = -360f;
    private float maximun_X = 360f;

    private float minimum_Y = -360f;
    private float maximun_Y = 360f;

    private Quaternion originalRotation;

    private float mouseSensivity = 1.7f;
	void Start () {
        originalRotation = transform.rotation;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        HandleRotation();
	}

    float ClampAngel(float angel,float min, float max)
    {
        if (angel < -360f)
        {
            angel += 360f;
        }
        if (angel > 360f)
        {
            angel -= 360f;
        }
        return Mathf.Clamp(angel, min, max);
    }

    void HandleRotation()
    {
        if(currentSensivity_X != mouseSensivity || currentSensivity_Y != mouseSensivity)
        {
            currentSensivity_X = currentSensivity_Y = mouseSensivity;
        }

        sensivity_X = currentSensivity_X;
        sensivity_Y = currentSensivity_Y;

        if(axes == RotationAxes.MouseX)
        {
            rotation_X += Input.GetAxis("Mouse X")*sensivity_X;

            rotation_X = ClampAngel(rotation_X, minimum_X, maximun_X);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotation_X, Vector3.up);

            transform.localRotation = originalRotation * xQuaternion;

        }

        if(axes == RotationAxes.MouseY)
        {
            rotation_Y += Input.GetAxis("Mouse Y") * sensivity_Y;

            rotation_Y = ClampAngel(rotation_Y, minimum_Y, maximun_Y);
            Quaternion yQuaterion = Quaternion.AngleAxis(-rotation_Y, Vector3.right);

            transform.localRotation = originalRotation * yQuaterion;

        }
         
    }
}
