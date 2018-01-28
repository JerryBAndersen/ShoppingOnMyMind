using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Collider))]
public abstract class TriggerArea : MonoBehaviour
{
	public MonoBehaviour[] containedObjects;

	public Dictionary<MonoBehaviour, bool> containing = new Dictionary<MonoBehaviour,bool>();
	public Collider triggerCollider;

	void Start(){
		triggerCollider = GetComponent<Collider> ();
		triggerCollider.isTrigger = true;
	}

	void Update(){
		containedObjects = new MonoBehaviour[containing.Count];
		containing.Keys.CopyTo (containedObjects,0);;
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

	public abstract void OnTriggerStay (Collider coll);
}

