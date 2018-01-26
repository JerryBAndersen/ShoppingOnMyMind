using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBodyParts : MonoBehaviour {

    public float speedVertical = 1000.0F;
    public float speedHorizontal = 1000.0F;
    public Rigidbody ArmLeft;
    public Rigidbody ArmRight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float verticalMove = Input.GetAxis("Vertical") * speedVertical;
        float horizontalMove = Input.GetAxis("Horizontal") * speedHorizontal;
        verticalMove *= Time.deltaTime;
        horizontalMove *= Time.deltaTime;
        Debug.Log(horizontalMove  + " ," +  verticalMove);

        Vector3 appliedForce;
        appliedForce = new Vector3(horizontalMove, 0,  verticalMove);
        ArmLeft.AddForce(appliedForce);
        ArmRight.AddForce(appliedForce);
    }
}
