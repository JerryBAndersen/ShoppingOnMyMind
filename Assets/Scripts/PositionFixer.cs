using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is very good programming - this script will stop the glichting
public class PositionFixer : MonoBehaviour {

    public GameObject blob;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
       
        if (Mathf.Abs(this.GetComponent<Transform>().position.x) > 20)
        {
            if (blob != null)
            {
                blob.SetActive(false);
            }
            this.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            this.gameObject.active = false;

            
        }
    }
        
}
