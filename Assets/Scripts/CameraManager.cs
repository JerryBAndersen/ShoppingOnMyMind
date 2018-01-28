using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject parent;

    public float closePos;
    public float farPos;

	// Update is called once per frame
	void Update () {
        Vector3 v = Vector3.zero;
        int i = 0;
        foreach (PlayerController p in GameController.players) {
            if (p != null)
            {
                v += p.root.transform.position;
                i++;
            }
        }
        if (i != 0)
        {
            parent.transform.position = v / i;
            float distance = 0;  
            for(int j = 0; j<i;j++)
            {
                float k = Vector3.Distance(parent.transform.position, GameController.players[j].root.transform.position);
                if (k > distance)
                {
                    distance = k;
                }
                //TODO richtig rauszoomen
               // transform.position = new Vector3(transform.position.x, transform.position.y, distance);
            }
        }


        //transform.position = Vector3.Lerp()
	}
}
