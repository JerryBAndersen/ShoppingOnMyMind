using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerId = -1;
	public List<string> shoppingList = new List<string> ();
	public List<string> forgotten = new List<string>();

	public List<string> bought = new List<string>();
	public List<string> stolen = new List<string>();

    public GameObject root;

	public float cash = 10;

	public bool DidBuyProduct(string product){
		return !forgotten.Contains (product);
	}

	public Color color{
		get { 
			return GameController.instance.playerColors[playerId];
		}
	}

	public bool Pay(Buyable buy){
		if (cash - buy.price >= 0) {
			cash -= buy.price;
			return true;
		} else {
			return false;
		}
	}

	private Rigidbody rigid;

	public float forceFactor = 100f;
	public float velocityLimit = 1f;

	void Awake(){
		
	}

	void Start () {
		rigid = GetComponent<Rigidbody> ();
        root = GetComponent<MoveBodyParts>().Root.gameObject;
	}
	
	/* Update is called once per frame
	void FixedUpdate () {
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");

		Vector3 vec = CameraControl.instance.transform.forward;
		vec.y = 0;
		Vector3 vec2 = CameraControl.instance.transform.right;
		vec2.y = 0;
		var vel = rigid.velocity;
		vel.y = 0;
		if (vel.magnitude < velocityLimit) {
			rigid.AddForce (ver*vec.normalized+hor*vec2.normalized, ForceMode.Impulse);		
		} 


	}
	*/
}
