using System;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public static GameController instance = null;
	public static bool isDebug = true;

	public static Dictionary<int,PlayerController> players = new Dictionary<int,PlayerController> ();
	public static List<NpcController> npcs = new List<NpcController> ();

	public Buyable[] possibleShoppingListItems;
	public int shoppingListLength = 10;

	public Color[] playerColors = {
		Color.red,Color.blue,Color.yellow,Color.cyan,
		Color.green,Color.magenta,Color.black,Color.grey
	};

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
			if (players [i] == null) {
				if (Input.GetButtonDown ("Start" + i)) {
					AddPlayer (i);		
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			EndGame ();
		}
	}

	public string GetRandomShoppingListItem(){
		int i = (int)(possibleShoppingListItems.Length * UnityEngine.Random.value);
		return possibleShoppingListItems [i].GetType().ToString ();
	}

	void AddPlayer(int i){
		int sel = (int)(UnityEngine.Random.value * npcs.Count);
		var n = npcs [sel];
		npcs.Remove (n);
		Destroy (n.GetComponent<NpcController>());
		var player = n.gameObject.AddComponent<PlayerController>();
		player.playerId = i;
		for(int j = 0; j < shoppingListLength; j++){
			player.shoppingList.Add(GetRandomShoppingListItem(),false);
		}
		players.Add (i,player);
		PaintInPlayerColor (player.gameObject,player.playerId);
	}

	public static void Paint(GameObject go, Color col){
		foreach(MeshRenderer mr in go.GetComponentsInChildren<MeshRenderer>()){
			mr.material.color = col;
		}	
	}

	public static void PaintInPlayerColor(GameObject go, int i){
		foreach(MeshRenderer mr in go.GetComponentsInChildren<MeshRenderer>()){
			mr.material.color = GameController.instance.playerColors[i];
		}	
	}

	void ChangePlayer(PlayerController player, NpcController n){
		// prepare new host
		npcs.Remove (n);
		Destroy (n.GetComponent<NpcController>());
		// add player to new host
		// THIS WONT WORK!! TODO
		//var p = n.gameObject.AddComponent<PlayerController>(player);
		// add npc to old host
		var npc = player.gameObject.AddComponent<NpcController> ();
		npcs.Add (npc);
		// destroy duplicate player
		Destroy (player);
		Paint (npc.gameObject,Color.white);
		//if (p == null) {
		//	throw new Exception ("player component null!");
		//}
		//players[player.playerId] = p;
	}

	public void EndGame(){
		foreach (var player in players.Values) {
			string output = "Player " + player.playerId + "\r\n\tgot:\r\n";
			foreach (var item in player.shoppingList) {
				if (!item.Value) {
					player.forgotten.Add (item.Key);
				} else {
					print ("\t" + item.Key + "\r\n");
				}
			}
			print ("forgot:\r\n");
			foreach(var item in player.forgotten){
				print ("\t" + item + "\r\n");
			}
			print ("stole:\r\n");
			foreach(var item in player.stolen){
				print ("\t" + item + "\r\n");
			}
			print (output);
		}	
	}
}

