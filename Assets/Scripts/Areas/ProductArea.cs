using System;
using UnityEngine;

public class ProductArea : TriggerArea
{
	public override void OnTriggerStay(Collider coll){
		Product c;
		if (c = coll.GetComponent<Product>()) {
			if (!containing.ContainsKey (c)) {
				containing.Add (c, true);
			} else {
				containing [c] = true;		
			}
		}	
	}
}

