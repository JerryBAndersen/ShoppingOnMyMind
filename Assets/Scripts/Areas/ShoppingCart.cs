using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
	public PlayerController current = null;
	public PlayerArea playerArea;
	public ProductArea itemArea;

	public void FixedUpdate(){
		if (playerArea.containedObjects.Length > 0) {
			if (current != null) {
				if (!playerArea.containing.ContainsKey (current)) {
					current = (PlayerController)playerArea.containedObjects[0];
					GameController.PaintInPlayerColor (gameObject, current.playerId);
				}
			} else {
				current = (PlayerController)playerArea.containedObjects[0];
				GameController.PaintInPlayerColor (gameObject, current.playerId);
			}
		}

	}

	public bool isEvaluated = false;
	public void Evaluate() {
		isEvaluated = true;
		foreach (var b in itemArea.containing) {
			var bu = (Buyable) b.Key;
			// was this on the shopping list?
			foreach (string needed in current.shoppingList) {
				if (bu.GetType ().ToString () == needed && bu.isPaid) {
					current.forgotten.Remove(needed);
					if (current.forgotten.Count == 0) {
						GameController.instance.EndGame ();
					}
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
