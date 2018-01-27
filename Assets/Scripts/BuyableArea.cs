using System;
using UnityEngine;

public class BuyableArea : TriggerArea
{
	public MonoBehaviour IsFilterType(Collider coll){
		return (MonoBehaviour)coll.GetComponent<Buyable> ();
	}
}

