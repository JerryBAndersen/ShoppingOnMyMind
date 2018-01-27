using UnityEngine;

public class CashRegister : BuyableArea
{
	public CashPoint cashPoint;

	public void FixedUpdate(){
		foreach (var item in containing) {
			if (item.Key is Buyable) {
				var buy = (Buyable)item.Key;
				if (!buy.isPaid && cashPoint.current != null) {
					buy.Buy (cashPoint.current);
					MakeCashRegisterSound ();
				}
			}
		}
	}

	public void MakeCashRegisterSound(){
		// TODO
		print("CHA CHING!");
	}
}
