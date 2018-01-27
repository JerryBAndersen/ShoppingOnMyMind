using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
	public PlayerController current = null;
	public PlayerArea playerArea;
	public BuyableArea buyableArea;

	public void FixedUpdate(){
		if (current != null) {
			if (playerArea.containing.ContainsKey (current)) {
				current = null;
			}
		} else {
			if (playerArea.containedObjects.Length > 0) {
				current = (PlayerController)playerArea.containedObjects[0];
				GameController.PaintInPlayerColor (gameObject, current.playerId);
			}
		}
	}

	public bool isEvaluated = false;
	public void Evaluate() {
		isEvaluated = true;
		foreach (var b in buyableArea.containing) {
			var bu = (Buyable) b.Key;
			// was this on the shopping list?
			foreach (string needed in current.shoppingList.Keys) {
				if (bu.GetType ().ToString () == needed) {
					current.shoppingList [needed] = true;
					break;
				}
			}
			// did anyone pay for this?
			if (bu.isPaid) {
				current.bought.Add (bu.GetType().ToString());
			} else {
				current.stolen.Add (bu.GetType().ToString());
			}
			Destroy (b.Key.gameObject);
		}
		Destroy (gameObject);
	}
}
