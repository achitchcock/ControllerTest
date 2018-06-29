using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class controllerInput : MonoBehaviour {

    public Text data;
    public Text LhorizText;
    public Text LvertText;
    public Text RhorizText;
    public Text RvertText;
    public Text DhorizText;
    public Text DvertText;
    public GameObject cube;
    public Camera droneCam;

    private string[] buttons = new string[] { "ButtonA", "ButtonB", "ButtonX", "ButtonY", "R1", "R2", "L1", "L2", "L3", "R3", "START", "SELECT"};

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        data.text = "";
        foreach( string key in buttons)
        {
            if (Input.GetButton(key)){
                data.text += key + " ";
            }
            
        }

        float LJV = Input.GetAxis("LeftJoystickVertical");
        float LJH = Input.GetAxis("LeftJoystickHorizontal");
        float RJV = Input.GetAxis("RightJoystickVertical");
        float RJH = Input.GetAxis("RightJoystickHorizontal");
        float DV = Input.GetAxis("DPadVertical");
        float DH = Input.GetAxis("DPadHorizontal");


        LvertText.text = "LeftJoystickVertical:"+ LJV.ToString();
        LhorizText.text = "LeftJoystickHorizontal" + LJH.ToString();
        RvertText.text = "RightJoystickVertical" + RJV.ToString();
        RhorizText.text = "RightJoystickHorizontal" + RJH.ToString();
        DvertText.text = "DPadVertical: " + DV.ToString();
        DhorizText.text = "DPadHorizontal: " + DH.ToString();
        float x = 0;
        float y = 0;
        float z = 0;
        float yaw = 0;
        float maxSpeed = 2f;
        float maxLift = 0.5f;
        float maxRotate = 4;


        if (Input.GetButton("L1") && droneCam.transform.localRotation.x  < 0.7f )
        {
            droneCam.transform.Rotate(Vector3.right * 2);
        }
        if (Input.GetButton("R1") && droneCam.transform.localRotation.x > 0 )
        {
            droneCam.transform.Rotate(Vector3.right * -2);
        }

        if ( Mathf.Abs(LJV) > 0.1f)
        {
            z = -LJV * maxSpeed;
        }

        if (Mathf.Abs(LJH) > 0.1f)
        {
            x = LJH * maxSpeed;
        }

        if (Mathf.Abs(RJV) > 0.1f)
        {
            y = -RJV * maxLift;
        }

        if (Mathf.Abs(RJH) > 0.1f)
        {
            yaw = RJH * maxRotate;
        }
        cube.transform.Rotate(Vector3.up * yaw);
        cube.transform.Translate(x, y, z);


    }
}
