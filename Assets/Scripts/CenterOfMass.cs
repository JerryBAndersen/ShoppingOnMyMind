using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour {

    public Vector3 centerOfMass;
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().centerOfMass = this.GetComponent<Rigidbody>().centerOfMass + centerOfMass;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
