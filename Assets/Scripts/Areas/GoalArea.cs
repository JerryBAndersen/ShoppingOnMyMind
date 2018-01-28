using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalArea : TriggerArea
{
	public override void OnTriggerStay(Collider coll){
		ShoppingCart c;
		if (c = coll.GetComponent<ShoppingCart>()) {
			if (!containing.ContainsKey (c)) {
				containing.Add (c, true);
			} else {
				containing [c] = true;		
			}
		}	
	}

	public void FixedUpdate(){
		foreach (var obj in containedObjects) {
			var cart = (ShoppingCart)obj;
			if (!cart.isEvaluated) {
				cart.Evaluate ();
			}
		}
	}
}

