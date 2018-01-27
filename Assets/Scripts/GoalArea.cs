using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BuyableArea))]
[RequireComponent(typeof(PlayerArea))]
public class GoalArea : MonoBehaviour
{
	public PlayerController assignedPlayer;
	BuyableArea buyableArea;

	void Start(){
		buyableArea = GetComponent<BuyableArea> ();
	}

	void EvaluateGoals(){
		List<Buyable> bought = new List<Buyable>();
		List<Buyable> stolen = new List<Buyable>();
		List<Buyable> forgotten = new List<Buyable>();
		foreach (var buy in assignedPlayer.shoppingList) {
			if (buyableArea.containing.ContainsKey ((MonoBehaviour)buy)) {
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

