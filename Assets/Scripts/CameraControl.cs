using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public static CameraControl instance = null;

	void Awake(){
		if (instance == null) {
			instance = this;		
		}		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 center = Vector3.zero;
		foreach (var player in GameController.players) {
			center += player.transform.position;
		}
		center.y = 0;
		center /= GameController.players.Count;
		transform.LookAt (center);
	}
}
