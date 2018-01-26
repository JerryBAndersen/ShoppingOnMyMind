using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerArea<T> : MonoBehaviour
{
	public Dictionary<T, bool> containing = new Dictionary<T,bool>();
	bool updated = false;

	void FixedUpdate ()
	{
		Dictionary<T, bool> last = new Dictionary<T, bool> (containing);
		foreach(var con in last){
			if (con.Value) {
				containing[con.Key] = false;
			} else {
				containing.Remove (con.Key);
			}
		}
	}

	void OnTriggerStay(Collider coll){
		T c;
		if (c = coll.GetComponent<T>) {
			if (!containing.ContainsKey (c)) {
				containing.Add (c, true);
			} else {
				containing [c] = true;		
			}
		}
	}
}

