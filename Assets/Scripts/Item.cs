using UnityEngine;

public class Item : MonoBehaviour
{
	Rigidbody rigid;
	Collider coll;

	void Start(){
		rigid = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
	}
}

