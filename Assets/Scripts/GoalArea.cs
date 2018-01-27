using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalArea : BuyableArea
{
	public PlayerController assignedPlayer;

	void EvaluateGoals(){
		List<Buyable> bought = new List<Buyable>();
		List<Buyable> stolen = new List<Buyable>();
		List<Buyable> forgotten = new List<Buyable>();
		foreach (var buy in assignedPlayer.shoppingList) {
			if (containing.ContainsKey ((MonoBehaviour)buy)) {
				if (assignedPlayer.boughtItems.Contains (buy)) {
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

