using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorBelt : MonoBehaviour {

    List<Rigidbody> rigids = new List<Rigidbody>();

    void OnTriggerEnter(Collider collider) {
        rigids.Add(collider.GetComponent<Rigidbody>());

    }

    void OnTriggerExit(Collider collider) {
        rigids.Remove(collider.GetComponent<Rigidbody>());
    }

    void Update()
    {
        for (int i = 0; i < rigids.Count; i++) {
            rigids[i].AddForce(Vector3.right);
        }
    }
       
}
