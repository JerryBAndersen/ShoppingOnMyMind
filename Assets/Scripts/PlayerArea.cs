using System;
using UnityEngine;

public class PlayerArea : TriggerArea
{
	public MonoBehaviour IsFilterType(Collider coll){
		return (MonoBehaviour)coll.GetComponent<PlayerController> ();
	}
}

