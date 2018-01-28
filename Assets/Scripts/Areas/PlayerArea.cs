using System;
using UnityEngine;

public class PlayerArea : TriggerArea
{
	public override void OnTriggerStay(Collider coll){
		PlayerController c;
		if (c = coll.GetComponentInParent<PlayerController>()) {
			if (!containing.ContainsKey (c)) {
				containing.Add (c, true);
			} else {
				containing [c] = true;		
			}
		}	
	}
}

