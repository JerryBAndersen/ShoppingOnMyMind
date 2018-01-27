using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour {

    
    public Rigidbody rb2D;
    public float xpos = 0.0F;
    public float ypos = 0.0F;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
       /* float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Debug.Log(translation + " ," + rotation);
       // transform.Translate(translation, 0, rotation);
       // transform.Rotate(0, rotation, 0);

       // rb2D = GetComponent<Rigidbody>();
        Vector3 pos;
        pos = new Vector3(rotation, 0, translation);
        rb2D.MovePosition(rb2D.position + pos);*/


    }
}
