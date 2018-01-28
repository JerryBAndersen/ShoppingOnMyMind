using UnityEngine;

public class CashRegister : ProductArea
{
	public PlayerArea playerArea;	
	public PlayerController current = null;
    public AudioSource ching;

	public void FixedUpdate(){
		if (current == null) {
			foreach (var item in playerArea.containing) {
				if (item.Key is PlayerController) {
					var player = (PlayerController)item.Key;
					current = player;
					GameController.PaintInPlayerColor (gameObject, player.playerId);
				}
			}
		} else {
			if (!playerArea.containing.ContainsKey (current)) {
				current = null;
				GameController.Paint(gameObject,Color.white);
			}
		}

		foreach (var item in containing) {
			if (item.Key is Buyable) {
				var buy = (Buyable)item.Key;
				if (!buy.isPaid && current != null) {
					buy.Buy (current);
					MakeCashRegisterSound ();
				}
			}
		}
	}

	public void MakeCashRegisterSound(){
        ching.Play();
		print("CHA cHING!");
	}
}
