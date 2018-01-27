using System;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public static GameController instance = null;

	public static List<PlayerController> players = new List<PlayerController> ();
	public static List<NpcController> npcs = new List<NpcController> ();

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	void Start(){
		npcs.AddRange (FindObjectsOfType<NpcController>());
	}

	void Update(){
		for(int i = 0; i < 8; i++){
			if(Input.GetButton("Start" + i)){
				AddPlayer (i);
			}	
		}
	}

	void AddPlayer(int i){
		int sel = (int)(UnityEngine.Random.value * npcs.Count);
		var n = npcs [sel];
		npcs.Remove (n);
		Destroy (n.GetComponent<NpcController>());
		var player = n.gameObject.AddComponent<PlayerController>();
		players.Add (player);
	}
}

