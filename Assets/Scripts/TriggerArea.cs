using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TriggerArea : MonoBehaviour
{
	public Dictionary<MonoBehaviour, bool> containing = new Dictionary<MonoBehaviour,bool>();
	public virtual MonoBehaviour GetFilterType (Collider coll){
		return (MonoBehaviour)coll.GetComponent<MonoBehaviour> ();
	}

	void FixedUpdate ()
	{
		Dictionary<MonoBehaviour, bool> last = new Dictionary<MonoBehaviour, bool> (containing);
		foreach(var con in last){
			if (con.Value) {
				containing[con.Key] = false;
			} else {
				containing.Remove (con.Key);
			}
		}
	}

	void OnTriggerStay(Collider coll){
		MonoBehaviour c;
		if (c = GetFilterType(coll)) {
			if (!containing.ContainsKey (c)) {
				containing.Add (c, true);
			} else {
				containing [c] = true;		
			}
		}	
	}
}

