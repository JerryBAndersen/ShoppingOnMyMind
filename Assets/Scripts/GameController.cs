using System;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public static GameController instance = null;
	public static List<PlayerController> players = new List<PlayerController> ();

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}
}

