using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
	public static GameController instance = null;
	public static bool isDebug = true;

	public static PlayerController[] players = new PlayerController[8];
	public static List<NpcController> npcs = new List<NpcController> ();

	public Product[] possibleShoppingListItems;
	public int shoppingListLength = 10;
	public List<string> shoppingList = new List<string> ();

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
		npcs.AddRange (FindObjectsOfType<NpcController> ());
		for(int j = 0; j < shoppingListLength; j++){
			string it = GetRandomShoppingListItem();
			while (shoppingList.Contains (it)) {
				it = GetRandomShoppingListItem();
			}
			shoppingList.Add(it);
		}
	}

	void Update(){
		for(int i = 0; i < 8; i++){
			if (Input.GetKeyDown (""+i) || Input.GetButtonDown ("Start"+i)) {
				if (players [i] == null) {
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
		string s = possibleShoppingListItems [i].GetType ().ToString ();
		return s;
	}

	public PlayerController[] GetPlayersThatBoughtProduct(string product){
		List<PlayerController> pleys = new List<PlayerController> ();
		foreach (var player in players) {
			if (player.DidBuyProduct(product)) {
				pleys.Add (player);
			}
		}
		return pleys.ToArray ();
	} 

	void AddPlayer(int i){
		if (npcs.Count > 0) {
			int sel = (int)(UnityEngine.Random.value-.01f * npcs.Count);
			var n = npcs [sel];
			npcs.Remove (n);
			n.GetComponent<NpcController> ().enabled = false;
			n.GetComponent<AICharacter> ().enabled = false;
			n.GetComponent<NavMeshAgent> ().enabled = false;
			n.GetComponent<MoveBodyParts> ().enabled = true;
			n.GetComponent<MoveBodyParts> ().controllerID = i;
			PaintInPlayerColor (n.gameObject,i);
			var player = n.gameObject.AddComponent<PlayerController>();
			player.playerId = i;
			string[] prods = new string[shoppingList.Count];
			shoppingList.CopyTo (prods); 
			player.shoppingList.AddRange (prods);
			player.forgotten.AddRange (prods);
			players[i] = (player);
			PaintInPlayerColor (player.gameObject,player.playerId);
		}
	}

	public static void Paint(GameObject go, Color col){
		foreach(MeshRenderer mr in go.GetComponentsInChildren<MeshRenderer>()){
			mr.material.color = col;
		}
		foreach(SkinnedMeshRenderer mr in go.GetComponentsInChildren<SkinnedMeshRenderer>()){
			mr.material.color = col;
		}
	}

	public static void PaintInPlayerColor(GameObject go, int i){
		Paint (go,GameController.instance.playerColors[i]);
	}
/*
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
*/
	public void EndGame(){
		foreach (var player in players) {
			string output = "Player " + player.playerId + "\r\n";
			foreach (var item in player.shoppingList) {
				if (player.forgotten.Contains(item)) {
					player.forgotten.Remove (item);
					output += ("\tforgot: " + item + "\r\n");
				} else {
					output += ("\tgot: " + item + "\r\n");
				}
			}
			foreach(var item in player.stolen){
				output +=  ("\tstole: " + item + "\r\n");
			}
			print (output);
		}	
	}
}

