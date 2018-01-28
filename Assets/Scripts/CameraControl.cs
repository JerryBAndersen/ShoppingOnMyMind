using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public static CameraControl instance = null;
	public Transform camera;
	public Transform highPoint;
	public Transform lowPoint;
	public Transform center;

	void Awake(){
		if (instance == null) {
			instance = this;		
		}		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float maxDist = 0f;
		center.position = Vector3.zero;
		foreach (var player in GameController.players) {
			if (player == null) {
				continue;
			}
			center.position += player.transform.position;
			foreach (var other in GameController.players) {
				if (other == player || other == null) {
					continue;
				}
				maxDist = Mathf.Max (maxDist,Vector3.Distance(other.transform.position,player.transform.position));
				center.position += player.transform.position;
			}
		}
		Vector3 flat = center.position;
		flat.y = 0;
		flat /= GameController.players.Length!=0?GameController.players.Length:1;
		center.position = flat;
		camera.transform.localPosition = Vector3.Lerp (lowPoint.localPosition,highPoint.localPosition,maxDist/30f);
	}
}
