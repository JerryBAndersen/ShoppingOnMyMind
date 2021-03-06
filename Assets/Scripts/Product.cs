﻿using UnityEngine;
using System.Collections;

public class Product : Item, Buyable
{
	public float _price = 2.99f;
	public float price{
		get{ 
			return _price;
		}
	}
	public bool _isPaid = false;
	public bool isPaid{
		get{ 
			return _isPaid;
		}
	}

	public void Buy(PlayerController player){
		if (player.Pay (this)) {
			_isPaid = true;
		}
	}
}

