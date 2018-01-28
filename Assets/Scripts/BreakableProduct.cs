using UnityEngine;

public class BreakableProduct : Product, Breakable
{
	public float breakForce = 301.0f;
	public GameObject fragmentsPrefab = null;
	public GameObject fragments = null;

	public bool isBroken{
		get{ 
			return fragments != null;
		}
	}

	void OnCollisionEnter(Collision c){
		var rel = c.relativeVelocity;
		var otherrigid = c.collider.GetComponent<Rigidbody> ();
		Vector3 averageNormal = Vector3.zero;
		foreach (var con in c.contacts) {
			averageNormal += con.normal;
		}
		averageNormal /= c.contacts.Length;

		var force = (otherrigid?otherrigid.mass:1f)*Vector3.Dot (rel, averageNormal);
		if (force > breakForce) {
			//Break ();
		}
	}

	public void Break(){
		if (fragmentsPrefab) {
			fragments = Instantiate (fragmentsPrefab, transform,false);
			fragments.transform.SetParent (null,true);
			foreach (var ri in fragments.GetComponentsInChildren<Rigidbody>()) {
				ri.velocity = rigid.velocity;
			}
		}
		Destroy (gameObject);
		MakeBreakSound ();
	}

	public virtual void MakeBreakSound(){
		// TODO
	}
}

