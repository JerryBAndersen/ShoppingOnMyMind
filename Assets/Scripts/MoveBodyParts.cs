using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBodyParts : MonoBehaviour {
    [Range(0, 7)]
    public int controllerID = 0;

    [Header("Movement Speeds")]
    //Movement Strenghts
    public float ArmSpeedVertical = 1000.0F;
    public float ArmSpeedHorizontal = 1000.0F;
    public float FootSpeedVertical = 1000.0F;
    public float FootSpeedHorizontal = 1000.0F;



    //Rigidbody parts
    [Header("Rigidbodies")]
    public Rigidbody ArmLeft;
    public Rigidbody ArmRight;
    public Rigidbody FootLeft;
    public Rigidbody FootRight;
    public Rigidbody Root;

    //Jumping
    [Header("Jumping")]
    [Range(0.0F, 3.0F)]
    public float timeToElapseTillNextJump = 1.0F; //1.0 is a good value
    [Range(0.0F, 100.0F)]
    public float JumpingStrength = 50.0F; //50.0 is a good value
    private float timeSinceLastJump = 0.0F;

    //Hand Joints
    [Header("Hand Joints")]
    public float GrabRadius = 1.0F;
    public GameObject GJ_HandLeft;
    public GameObject GJ_HandRight;
    public FixedJoint HandLeft;
    public FixedJoint HandRight;
    public Transform HandLeftPosition;
    public Transform HandRightPosition;
    public string LeftGrabButton = "leftGrabButton_";
    public string RightGrabButton = "rightGrabButton_";
    private bool grabbingActiveLeft = false;
    private bool grabbingActiveRight = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ARM MOVEMENT ------------------------------------------------------------------
        //Get Controller Analogstick Data
        float Arm_verticalMove = Input.GetAxis("Vertical_8_" + controllerID.ToString()) * ArmSpeedVertical;
        float Arm_horizontalMove = Input.GetAxis("Horizontal_8_" + controllerID.ToString()) * ArmSpeedHorizontal;
        //No Framerate dependency
        Arm_verticalMove *= Time.deltaTime;
        Arm_horizontalMove *= Time.deltaTime;
        //Debug.Log("Arm: " + Arm_horizontalMove + ", " + Arm_verticalMove);

        //FOOT MOVEMENT - NO COPY PASTA -----------------------------------------
        //Get Controller Analogstick Data
        float Foot_verticalMove = Input.GetAxis("Vertical_9_" + controllerID.ToString()) * FootSpeedVertical;
        float Foot_horizontalMove = Input.GetAxis("Horizontal_9_" + controllerID.ToString()) * FootSpeedHorizontal;
        //No Framerate dependency
        Foot_verticalMove *= Time.deltaTime;
        Foot_horizontalMove *= Time.deltaTime;
        //Debug.Log("Foot: " + Foot_horizontalMove + ", " + Foot_verticalMove);


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

    void FixedUpdate()
    {
        //Check grabbing status and change it accordingly
        updateGrabbingStatus();

        //Jump
        if (Input.GetButtonDown("Jump_" + controllerID.ToString()))
        {
            this.Jumping(JumpingStrength);
            Debug.Log(controllerID);
        }
    }
    void updateGrabbingStatus()
    {
        //Grab Button Pressed -- LEFT --
        if (Input.GetButtonDown(LeftGrabButton + controllerID.ToString()))
        {
            if (!grabbingActiveLeft)
            {
                Debug.Log(controllerID);
                Debug.Log("I am trying to grab stuff!");
                //Call Function to grab stuff
                grabbingActiveLeft = grabStuff(GJ_HandLeft);            
            }
        } //Grab Button not Pressed
        else
        {
            if (grabbingActiveLeft)
            {
                clearGrabbing(GJ_HandLeft);
                grabbingActiveLeft = false;
                //Clear Joint
            }
        }

        //Grab Button Pressed -- LEFT --
        if (Input.GetButtonDown(RightGrabButton + controllerID.ToString()))
        {
            if (!grabbingActiveRight)
            {
                Debug.Log("I am trying to grab stuff!");
                //Call Function to grab stuff
                grabbingActiveRight = grabStuff(GJ_HandRight);
            }
        } //Grab Button not Pressed
        else
        {
            if (grabbingActiveRight)
            {
                clearGrabbing(GJ_HandRight);
                grabbingActiveRight = false;
                //Clear Joint
            }
        }
    }
    //Grabstuff in range of GameObject and return Success/Fail
    bool grabStuff(GameObject Hand)
    {
        float radius = GrabRadius;
        Collider[] colliders;

        //Check Collision around Hand
        colliders = Physics.OverlapSphere(Hand.transform.position, radius);
        if(colliders.Length > 0) //Something is in there
        {
            FixedJoint JointHand;
            
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.name == "ShopingCart")
                {
                    JointHand = Hand.AddComponent<FixedJoint>();
                    Debug.Log(colliders[i]);
                    //Take whatever is in there connects its rigidbody with the joint
                    JointHand.connectedBody = colliders[i].gameObject.GetComponent<Rigidbody>();
                    JointHand.breakForce = 1000.0F;
                    JointHand.breakTorque = 2000.0F;
                    Debug.Log(colliders[i].gameObject.GetComponent<Rigidbody>());
                }

            }
            
           
            return true;
        }
        else
        {
            return false;
        }
    }

    void clearGrabbing(GameObject Hand)
    {
        if(Hand.GetComponent<FixedJoint>() != null)
        Destroy(Hand.GetComponent<FixedJoint>());
    }

    void Jumping(float strength)
    {
        //Some time has to elapse to jump again
        if (timeSinceLastJump + timeToElapseTillNextJump < Time.time)
        {
            timeSinceLastJump = Time.time;
            Root.AddForce(new Vector3(0, strength, 0), ForceMode.Impulse);
        }
    }

    
}
