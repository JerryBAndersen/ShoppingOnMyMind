public interface Buyable
{
	bool isPaid { get;}
	float price { get;}

	void Buy (PlayerController player);
}

