using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBodyParts : MonoBehaviour {

    public float ArmSpeedVertical = 1000.0F;
    public float ArmSpeedHorizontal = 1000.0F;

    public float FootSpeedVertical = 1000.0F;
    public float FootSpeedHorizontal = 1000.0F;

    public Rigidbody ArmLeft;
    public Rigidbody ArmRight;
    public Rigidbody FootLeft;
    public Rigidbody FootRight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ARM MOVEMENT ------------------------------------------------------------------
        //Get Controller Analogstick Data
        float Arm_verticalMove = Input.GetAxis("Vertical_8") * ArmSpeedVertical;
        float Arm_horizontalMove = Input.GetAxis("Horizontal_8") * ArmSpeedHorizontal;
        //No Framerate dependency
        Arm_verticalMove *= Time.deltaTime;
        Arm_horizontalMove *= Time.deltaTime;
        Debug.Log("Arm: " + Arm_horizontalMove + ", " + Arm_verticalMove);

        //FOOT MOVEMENT - NO COPY PASTA -----------------------------------------
        //Get Controller Analogstick Data
        float Foot_verticalMove = Input.GetAxis("Vertical_9") * FootSpeedVertical;
        float Foot_horizontalMove = Input.GetAxis("Horizontal_9") * FootSpeedHorizontal;
        //No Framerate dependency
        Foot_verticalMove *= Time.deltaTime;
        Foot_horizontalMove *= Time.deltaTime;
        Debug.Log("Foot: " + Foot_horizontalMove + ", " + Foot_verticalMove);


        //Make into a Force
        Vector3 Arm_appliedForce;
       Arm_appliedForce = new Vector3(Arm_horizontalMove, 0, Arm_verticalMove);
        Vector3 Foot_appliedForce;
        Foot_appliedForce = new Vector3(Foot_horizontalMove, 0, Foot_verticalMove);

        //Apply Force (Move the Rigidbody)
       ArmLeft.AddForce(Arm_appliedForce);
        ArmRight.AddForce(Arm_appliedForce);
        FootLeft.AddForce(Foot_appliedForce);
        FootRight.AddForce(Foot_appliedForce);
    }
}
