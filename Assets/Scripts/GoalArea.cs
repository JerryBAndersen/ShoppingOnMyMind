using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalArea : MonoBehaviour
{
	public PlayerController player;

	[RequireComponent(typeof(TriggerArea<Buyable>))]
	TriggerArea<Buyable> buyableArea;
	[RequireComponent(typeof(TriggerArea<PlayerController>))]
	TriggerArea<PlayerController> playerArea;

	void Start(){
		buyableArea = GetComponent<TriggerArea<Buyable>> ();
		playerArea = GetComponent<TriggerArea<PlayerController>> ();
	}

	void EvaluateGoals(){
		List<Buyable> bought = new List<Buyable>();
		List<Buyable> stolen = new List<Buyable>();
		List<Buyable> forgotten = new List<Buyable>();
		foreach (var buy in player.shoppingList) {
			if (buyableArea.containing.ContainsKey (buy)) {
				if (player.boughtItems.Contains (buy)) {
					bought.Add (buy);
				} else {
					stolen.Add (buy);
				}
			} else {
				forgotten.Add (buy);
			}
		}
	}
}

