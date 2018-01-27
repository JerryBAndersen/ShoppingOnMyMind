using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;
    public float speed = 1;
    
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);

	}
}
