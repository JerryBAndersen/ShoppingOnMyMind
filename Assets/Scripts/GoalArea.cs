using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalArea : TriggerArea
{
	public MonoBehaviour IsFilterType(Collider coll){
		return (MonoBehaviour)coll.GetComponent<ShoppingCart> ();
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

