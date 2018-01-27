using UnityEngine;

public class Item : MonoBehaviour
{
	public Rigidbody rigid;
	public Collider coll;

	public virtual void Start(){
		rigid = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
	}
	public virtual void Update ()
	{
	}
}

