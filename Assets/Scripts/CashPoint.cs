using UnityEngine;

public class CashPoint : PlayerArea
{
	public PlayerController current = null;
	public void FixedUpdate(){
		if (current == null) {
			foreach (var item in containing) {
				if (item.Key is PlayerController) {
					var player = (PlayerController)item.Key;
					current = player;
					GameController.PaintInPlayerColor (gameObject, player.playerId);
				}
			}
		} else {
			if (!containing.ContainsKey (current)) {
				current = null;
				GameController.Paint(gameObject,Color.white);
			}
		}
	}
}
